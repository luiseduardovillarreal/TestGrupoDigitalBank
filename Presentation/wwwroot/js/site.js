function loadEditModal(btn) {
    document.getElementById('editId').value = btn.getAttribute('data-id');
    document.getElementById('editNames').value = btn.getAttribute('data-names');
    document.getElementById('editDateOfBirth').value = btn.getAttribute('data-dateofbirth');
    document.getElementById('editIdGender').value = btn.getAttribute('data-idgender');
}

function loadDeleteModal(btn) {
    document.getElementById('deleteId').value = btn.getAttribute('data-id');
    document.getElementById('deleteUserName').textContent = btn.getAttribute('data-names');
}