function DynamicAdd() {
    var division = document.createElement('div');
    division.innerHTML = DynamicTextBox("");
    document.getElementById("firstDiv").appendChild(division);
}
function DynamicTextBox(value) {
    return '<div><input type="text" name="ingredientName" class="form-control" placeholder="Име"/><input type="text" name="ingredientQuantity" class="form-control" placeholder="Количество"/><input type="button" onclick="ReTextBox(this)" value="Изтрий" /></div>';
}
function ReTextBox(div) {
    
    document.getElementById("firstDiv").removeChild(div.parentNode.parentNode);
}
