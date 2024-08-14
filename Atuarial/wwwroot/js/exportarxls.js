function exportTableToExcel(filename, tableId) {
    var table = document.querySelector(tableId);
    var wb = XLSX.utils.table_to_book(table, { sheet: "Sheet1" });
    var wbout = XLSX.write(wb, { bookType: "xlsx", type: "binary" });

    function s2ab(s) {
        var buf = new ArrayBuffer(s.length);
        var view = new Uint8Array(buf);
        for (var i = 0; i < s.length; i++) view[i] = s.charCodeAt(i) & 0xFF;
        return buf;
    }

    var blob = new Blob([s2ab(wbout)], { type: "application/octet-stream" });

    var link = document.createElement("a");
    link.href = window.URL.createObjectURL(blob);
    link.download = filename;
    link.click();
}
