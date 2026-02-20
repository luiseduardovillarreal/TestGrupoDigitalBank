using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading.Tasks;
using PropertyAttributes = System.Reflection.PropertyAttributes;

/// <summary>
/// Descripción breve de ExecuteQuery
/// </summary>
public class ExecuteQuery : IExecuteQuery
{
    private readonly ITestGrupoDigitalBankDbContext _dbContext;

    public ExecuteQuery(ITestGrupoDigitalBankDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> ExecuteSentenceSQL(string storedProcedure, List<SqlParameter> parameters)
    {
        DataTable dt = new DataTable();
        ResultQuery resultQuery = new ResultQuery();
        try
        {
            using (var cmd = _dbContext.Database.Connection.CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = storedProcedure;

                foreach (var item in parameters)
                    cmd.Parameters.Add(item);

                cmd.Connection.Open();
                DbDataReader reader = await cmd.ExecuteReaderAsync();
                dt.Load(reader);
                reader.Close();
                cmd.Connection.Close();
                List<dynamic> dynamics = DataTableExtension.ToDynamicList(dt,
                    Constants.GenericQuery.ExecuteQuery.REPORTS);
                var columns = dt.Columns.Cast<DataColumn>();
                var lstColumns = columns.Select(x => x.ColumnName).ToList();
                DataDynamic dataDynamic = new DataDynamic()
                {
                    columns = lstColumns,
                    data = dynamics
                };
                resultQuery.Result = dataDynamic;
                resultQuery.State = true;
            }
        }
        catch (Exception ex)
        {
            resultQuery.Result = ex.Message;
            resultQuery.State = false;
        }
        var settings = new JsonSerializerSettings
        {
            Converters = new List<JsonConverter> { new DecimalJsonConverter() }
        };
        return JsonConvert.SerializeObject(resultQuery);
    }

    private class ResultQuery
    {
        public bool State { get; set; }
        public object Result { get; set; }
    }

    private class DataDynamic
    {
        public List<string> columns { get; set; }
        public object data { get; set; }
    }

    public static class DataTableExtension
    {
        public static List<dynamic> ToDynamicList(DataTable dt, string className)
        {
            return ToDynamicList(ToDictionary(dt), getNewObject(dt.Columns, className));
        }

        private static List<Dictionary<string, object>> ToDictionary(DataTable dt)
        {
            var columns = dt.Columns.Cast<DataColumn>();
            var Temp = dt.AsEnumerable().Select(dataRow => columns.Select(column =>
                                 new { Column = column.ColumnName, Value = dataRow[column] })
                             .ToDictionary(data => data.Column, data => data.Value)).ToList();
            return Temp.ToList();
        }

        private static List<dynamic> ToDynamicList(List<Dictionary<string, object>> list, Type TypeObj)
        {
            dynamic temp = new List<dynamic>();
            foreach (Dictionary<string, object> step in list)
            {
                object Obj = Activator.CreateInstance(TypeObj);
                PropertyInfo[] properties = Obj.GetType().GetProperties();
                Dictionary<string, object> DictList = step;

                foreach (KeyValuePair<string, object> keyValuePair in DictList)
                    foreach (PropertyInfo property in properties)
                        if (property.Name == keyValuePair.Key)
                        {
                            if (keyValuePair.Value != null && keyValuePair.Value.GetType() != typeof(DBNull))
                                if (keyValuePair.Value.GetType() == typeof(Guid))
                                    property.SetValue(Obj, keyValuePair.Value, null);
                                else
                                    property.SetValue(Obj, keyValuePair.Value, null);
                            break;
                        }
                temp.Add(Obj);
            }
            return temp;
        }

        private static Type getNewObject(DataColumnCollection columns, string className)
        {
            AssemblyName assemblyName = new AssemblyName();
            assemblyName.Name = Constants.GenericQuery.ExecuteQuery.YOUR_ASSEMBLY;

            AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName,
                AssemblyBuilderAccess.Run);
            ModuleBuilder module = assemblyBuilder.DefineDynamicModule(
                Constants.GenericQuery.ExecuteQuery.YOUR_DYNAMIC_MODULE);
            TypeBuilder typeBuilder = module.DefineType(className, TypeAttributes.Public);

            foreach (DataColumn column in columns)
            {
                string propertyName = column.ColumnName;
                FieldBuilder field = typeBuilder.DefineField(propertyName, column.DataType,
                    FieldAttributes.Public);
                PropertyBuilder property = typeBuilder.DefineProperty(propertyName, PropertyAttributes.None,
                    column.DataType, new Type[] { column.DataType });
                MethodAttributes GetSetAttr = MethodAttributes.Public | MethodAttributes.HideBySig;
                MethodBuilder currGetPropMthdBldr = typeBuilder.DefineMethod(
                    Constants.GenericQuery.ExecuteQuery.GET_VALUE, GetSetAttr, column.DataType,
                    new Type[] { column.DataType });
                ILGenerator currGetIL = currGetPropMthdBldr.GetILGenerator();
                currGetIL.Emit(OpCodes.Ldarg_0);
                currGetIL.Emit(OpCodes.Ldfld, field);
                currGetIL.Emit(OpCodes.Ret);
                MethodBuilder currSetPropMthdBldr = typeBuilder.DefineMethod(
                    Constants.GenericQuery.ExecuteQuery.SET_VALUE, GetSetAttr, null, new Type[] { column.DataType });
                ILGenerator currSetIL = currSetPropMthdBldr.GetILGenerator();
                currSetIL.Emit(OpCodes.Ldarg_0);
                currSetIL.Emit(OpCodes.Ldarg_1);
                currSetIL.Emit(OpCodes.Stfld, field);
                currSetIL.Emit(OpCodes.Ret);
                property.SetGetMethod(currGetPropMthdBldr);
                property.SetSetMethod(currSetPropMthdBldr);
            }
            Type obj = typeBuilder.CreateType();
            return obj;
        }
    }
}