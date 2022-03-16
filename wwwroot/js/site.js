async function  logIn (){
    var formData = new FormData();

    let UserName = document.getElementById("inputEmail3").value;
    let PassWord = document.getElementById("inputPassword3").value;

    formData.append("UserName" , UserName);
    formData.append("PassWord" , PassWord);

    fetch('/Home/LogInPost', {
        method: 'POST',
        body: formData
    }).then(res => {
        res.text().then(data =>{
            if (data == "Admin") {
                window.location.href = "/Admin/Index"
            } else {
                if(data != "No_One"){
                    window.location.href = "/Client/ShowMessages?Name=" + data
                }
            }
        })
    });
    
}

function  SignUp (){
    var formData = new FormData();
    let UserName = document.getElementById("name").value;
    let Email = document.getElementById("Email").value;
    let PassWord = document.getElementById("PassWord").value;
    let ConfirmPassWord = document.getElementById("ConfirmPassWord").value;
    let Mobile = document.getElementById("Mobile").value;
    formData.append("UserName" , UserName);
    formData.append("Email" , Email);
    formData.append("PassWord" , PassWord);
    formData.append("ConfirmPassWord" , ConfirmPassWord);
    formData.append("Mobile" , Mobile);
    fetch('/Home/SignUpPost', {
                method: 'POST',
                body: formData
            }).then(res =>{
                res.text().then(data =>{
                    if (data == "Done") {
                        window.location.href = "/Home/LogIn_Arabic";
                    }else{
                        alert("Failed :(");

                    }
                })
    });
}
function SaveEdits(ItemId){
    var EditName = document.getElementById("EditName").value;
    var EditEmail = document.getElementById("EditEmail").value;
    var EditNumber = document.getElementById("EditNumber").value;
    var EditPassWord = document.getElementById("EditPassWord").value;
    var EditConfirmPassWord = document.getElementById("EditConfirmPassWord").value;
    var EditImage = document.getElementById("FileImage");

    var data = new FormData();

    data.append("EditName" , EditName);
    data.append("EditEmail" , EditEmail);
    data.append("EditNumber" , EditNumber);
    data.append("EditPassWord" , EditPassWord);
    data.append("EditConfirmPassWord" , EditConfirmPassWord);
    data.append("EditImage" , EditImage);
    data.append("ItemId" , ItemId);
    
    fetch('/Client/EditDataPost', {
        method: 'POST',
        body: data,
        headers: {
			"Content-Type": "application/json",
			"Accept": "application/json"
		},
    }).then(res => {
        res.text().then(data => {
            if (data == "Done") {
                window.location.href = "/Client/ShowMessages?Name=" + EditName
            } else {
                alert("Failed :(");
            }
        })
    })
}
var EnterClient = (ClientName)=>{
    window.location.href = "/Client/ShowMessages?Name=" + ClientName;
}
var ActivateClient = (ClientName)=>{
    window.location.href = "/Admin/ActivateClient?Name=" + ClientName;
}
var DeactivateClient = (ClientName)=>{
    window.location.href = "/Admin/DeactivateClient?Name=" + ClientName;
}
var RemoveClient = (ClientName)=>{
    window.location.href = "/Admin/RemoveClient?Name=" + ClientName;
}
var ActivateClient_Arabic = (ClientName)=>{
    window.location.href = "/Admin/ActivateClient_Arabic?Name=" + ClientName;
}
var DeactivateClient_Arabic = (ClientName)=>{
    window.location.href = "/Admin/DeactivateClient_Arabic?Name=" + ClientName;
}
var RemoveClient_Arabic = (ClientName)=>{
    window.location.href = "/Admin/RemoveClient_Arabic?Name=" + ClientName;
}