// toogle
function montest() {
    $("#vire").slideToggle("slow");
}

//show
function showCategory(divId) {
    divPrecedent.style.display = "none";
    divPrecedent = document.getElementById(divId);
    divPrecedent.style.display = '';
}

//switcher recherche plein texte
function switcherSearchText(val) {
    
    crit1 = document.getElementById("criteria1");
    crit2 = document.getElementById("criteria2");

    //supprime contenu des champs
    crit1.value = "";
    crit2.value = "";

    //enable / disable
    if (val.checked == true) {
        crit1.disabled = false;
        crit2.disabled = false;
    }

    if (val.checked == false) {
        crit1.disabled = true;
        crit2.disabled = true;
    }

}

//switcher themes
function switcherSearchTheme(val) {

    //si switcher ON
    if (val.checked == true) {
        $('#Checkbox1').bootstrapToggle('enable');
        $('#Checkbox2').bootstrapToggle('enable');
        $('#Checkbox3').bootstrapToggle('enable');
        $('#Checkbox4').bootstrapToggle('enable');
    }

    //si switcher OFF
    if (val.checked == false) {

        //passe les switch de themes en OFF
        $('#Checkbox1').bootstrapToggle('off');
        $('#Checkbox2').bootstrapToggle('off');
        $('#Checkbox3').bootstrapToggle('off');
        $('#Checkbox4').bootstrapToggle('off');

        //passe les switch de themes en disabled
        $('#Checkbox1').bootstrapToggle('disable');
        $('#Checkbox2').bootstrapToggle('disable');
        $('#Checkbox3').bootstrapToggle('disable');
        $('#Checkbox4').bootstrapToggle('disable'); 

    }

}

//switcher sentiments
function switcherSearchFeeling(val) {

    //si switcher ON
    if (val.checked == true) {
        //passe les switch de themes en enable
        $('#Checkbox5').bootstrapToggle('enable');
        $('#Checkbox6').bootstrapToggle('enable');
        $('#Checkbox7').bootstrapToggle('enable');
    }

    //si switcher OFF
    if (val.checked == false) {

        //passe les switch de themes en OFF
        $('#Checkbox5').bootstrapToggle('off');
        $('#Checkbox6').bootstrapToggle('off');
        $('#Checkbox7').bootstrapToggle('off');

        //passe les switch de themes en disabled
        $('#Checkbox5').bootstrapToggle('disable');
        $('#Checkbox6').bootstrapToggle('disable');
        $('#Checkbox7').bootstrapToggle('disable');
    }
}

//switcher date
function switcherSearchDate(val) {

    start = document.getElementById("startDate");
    end = document.getElementById("endDate");
    startBtn = document.getElementById("startDateBtn");

    //si switcher ON
    if (val.checked == true) {
        //passe les dates enable
        end.readOnly = false;
        start.readOnly = false;
        startBtn.disabled = true;
    }

    //si switcher OFF
    if (val.checked == false) {
        //passe les dates en disabled
        end.readOnly = true;
        start.readOnly = true;
        $('.endDate').datepicker('hide');
    }
}
 