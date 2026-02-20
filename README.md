# TestGrupoDigitalBank
# 🚀 INSTALACIÓN

## Paso 0: Ejecutar el Script SQL situado en la carpeta SQL, en una base de datos Microsof SQL Server.

## Paso 1: Clonar el proyecto desde el CLI (CMD, Git, PowerShell, etc.) o desde la UI de Visual Studio.
```bash
    git clone https://github.com/luiseduardovillarreal/TestGrupoDigitalBank.git
```

## Paso 2: Configurar la conexión de la base de datos
Edita el archivo `web.config del proyecto WCF`:
```bash
    Conexión a la DB (En mi caso local con Autenticación de usuario): 
		<add name="connTestGrupoDigitalBankDbContext" connectionString="Data Source=localhost\SQLEXPRESS; Initial Catalog=TestGrupoDigitalBank; User ID=testGrupoDigitalBank; Password=123456; MultipleActiveResultSets=True" providerName="System.Data.SqlClient" />
```

## Paso 3: Limpiar y recompilar la solución.

## Paso 4: Iniciar los proyectos (Se abrirán en el navegador predeterminado).

## ¡Listo!