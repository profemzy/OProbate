$(document).ready(function () {
        var table = $("#archives")
            .DataTable({
                ajax: {
                    url: "/api/archives",
                    dataSrc: ""
                },
                columns: [
                    {
                        data: "name",
                        render: function(data, type, archive) {
                            return "<a href='/archives/details/" + archive.id + " '>" + archive.name + "</a>";
                        }
                    },
                    {
                        data: "caseDate"
                    },
            {
                data: "id",
                render: function(data) {
                    return "<button class= 'btn-link js-delete'  data-archive-id=" + data + ">Delete</button>";
                }
            }
        ]
    });

    $("#archives").on("click", ".js-delete", function () {
        var button = $(this);

        bootbox.confirm("Are you sure you want to delete this archive?",
            function(result) {
                if (result) {
                    $.ajax({
                        url: "/api/archives/" + button.attr("data-archive-id"),
                        method: "DELETE",
                        success: function () {
                            //button.parents("tr").remove();
                            table.row(button.parents("tr")).remove().draw();
                        }
                    }); 
                }
            });
       
    });
});


