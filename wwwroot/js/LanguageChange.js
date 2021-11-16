function changeLanguage(){
    var language = document.getElementById("language-change").innerHTML;
    if (language == 'FR') {
        document.getElementById("language-change").innerHTML = "EN";
        //change language to french 
    }
    else if (language == 'EN') {
        document.getElementById("language-change").innerHTML = "FR";
        //change lanuage to english
    }
}
