$(function () {
    var l = abp.localization.getResource('BookStoreResource');
    var dataTable = $('#BooksTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[0, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(
                Acme.BookStore.books.book.getList),
            columnDefs: [
                {
                    title: l('Title'),
                    data: "Title"
                },
                {
                    title: l('Author'),
                    data: "Author",
                    orderable: false
                },
                {
                    title: l('Price'),
                    data: "price"
                },
                {
                    title: l('Status'),
                    data: "Status",
                    render: function (data) {
                        return l('Enum:BookStatus:' + data);
                    }
                },
                {
                    title: l('CreationTime'),
                    data: "creationTime",
                    dataFormat: 'date'
                },
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    confirmMessage: function (data) {
                                        return l('ProductDeletionConfirmationMessage', data.record.name);
                                    },
                                    action: function (data) {
                                        zhaoxi.productManagement.products.product.delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(l('SuccessfullyDeleted'));
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                }
            ]
        })
    );
    var createModal = new abp.ModalManager(abp.appPath + 'Books/CreateBookModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Books/EditBookModal');

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#AddButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
