// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function autocomplete(searchEle, arr) {
    var currentFocus;
    searchEle.addEventListener("input", function(e) {
        var divCreate,
        b,
        i,
        fieldVal = this.value;
        closeAllLists();
        if (!fieldVal) {
            return false;
        }
        currentFocus = -1;
        divCreate = document.createElement("DIV");
        divCreate.setAttribute("id", this.id + "autocomplete-list");
        divCreate.setAttribute("class", "autocomplete-items");
        this.parentNode.appendChild(divCreate);
        for (i = 0; i <arr.length; i++) {
            if ( arr[i].substr(0, fieldVal.length).toUpperCase() == fieldVal.toUpperCase() ) {
                var l = arr[i].split(" ");
                l = l[l.length-1];
                b = document.createElement("DIV");
                b.innerHTML = "<a href ='/Vrhovi/Vrh/" + l + "'>";
                b.innerHTML += "<strong>" + arr[i].substr(0, fieldVal.length) + "</strong>";
                b.innerHTML += arr[i].substr(fieldVal.length, arr[i].length-l.length-1);
                b.innerHTML += "<input type='hidden' value='" + arr[i] + "'>";
                b.innerHTML += "</a>";
                b.addEventListener("click", function(e) {
                    searchEle.value = this.getElementsByTagName("input")[0].value;
                    closeAllLists();
                });
                divCreate.appendChild(b);
            }
        }
    });
    searchEle.addEventListener("keydown", function(e) {
        var autocompleteList = document.getElementById(
            this.id + "autocomplete-list"
        );
        if (autocompleteList)
            autocompleteList = autocompleteList.getElementsByTagName("div");
        if (e.keyCode == 40) {
            currentFocus++;
            addActive(autocompleteList);
        }
        else if (e.keyCode == 38) {
            //up
            currentFocus--;
            addActive(autocompleteList);
        }
        else if (e.keyCode == 13) {
            e.preventDefault();
            if (currentFocus > -1) {
            if (autocompleteList) autocompleteList[currentFocus].click();
            }
        }
    });
    function addActive(autocompleteList) {
        if (!autocompleteList) return false;
            removeActive(autocompleteList);
        if (currentFocus >= autocompleteList.length) currentFocus = 0;
        if (currentFocus < 0) currentFocus = autocompleteList.length - 1;
        autocompleteList[currentFocus].classList.add("autocomplete-active");
    }
    function removeActive(autocompleteList) {
        for (var i = 0; i < autocompleteList.length; i++) {
            autocompleteList[i].classList.remove("autocomplete-active");
        }
    }
    function closeAllLists(elmnt) {
        var autocompleteList = document.getElementsByClassName(
            "autocomplete-items"
        );
        for (var i = 0; i < autocompleteList.length; i++) {
            if (elmnt != autocompleteList[i] && elmnt != searchEle) {
            autocompleteList[i].parentNode.removeChild(autocompleteList[i]);
            }
        }
    }
    document.addEventListener("click", function(e) {
        closeAllLists(e.target);
    });
}