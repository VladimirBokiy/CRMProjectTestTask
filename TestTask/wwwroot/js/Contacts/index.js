var Confirm = function(){
    $("#CntId").val(document.querySelector('.updateId').value);
    $("#deleteContactPopup").modal('show');
}
var EditForm = function (id){
    console.log(id);
    $.ajax({
        type:"GET",
        url:"/Contacts/GetContact",
        data:{contactId:id},
        success: function (contact){
            $("#editContactPopup").modal('show');
            $(".updateId").val(contact.contactId);
            $("#cntName").val(contact.name);
            $("#cntSurname").val(contact.surname);
            $("#cntBirthDate").val(contact.birthDate);
            $("#cntJobTitle").val(contact.jobTitle);
            $("#cntMobilePhone").val(contact.mobilePhone)
        }
    })
}

var Cancel = function (){
    window.location.href = "/Contacts";
}

const addForm = document.getElementById("addContactForm");
const editForm = document.getElementById("editContactForm");
const nameEdit = document.getElementById("cntName");
const surnameEdit = document.getElementById("cntSurname");
const jobTitleEdit = document.getElementById("cntJobTitle");
const mobilePhoneEdit = document.getElementById("cntMobilePhone");
const nameAdd = document.getElementById("name");
const surnameAdd = document.getElementById("surname");
const jobTitleAdd = document.getElementById("jobTitle");
const mobilePhoneAdd = document.getElementById("mobilePhone");

addForm.addEventListener("submit", e => {
    validateInputs(e, nameAdd, surnameAdd, jobTitleAdd, mobilePhoneAdd);
})

 editForm.addEventListener("submit", e => {
     validateInputs(e, nameEdit, surnameEdit, jobTitleEdit, mobilePhoneEdit);
 })

const setSuccess = element => {
    const inputControl = element.parentElement;
    const errorDisplay = inputControl.querySelector('.error');

    errorDisplay.innerText = '';
    inputControl.classList.add('success');
    inputControl.classList.remove('error');
};

const setError = (element, message) => {
    const inputControl = element.parentElement;
    const errorDisplay = inputControl.querySelector('.error');

    errorDisplay.innerText = message;
    inputControl.classList.add('error');
    inputControl.classList.remove('success')
}

const validateInputs = (e, name, surname, jobTitle, mobilePhone) => {
    const nameValue = name.value.trim();
    const surnameValue = surname.value.trim();
    const jobTitleValue = jobTitle.value.trim();
    const mobilePhoneValue = mobilePhone.value.trim();

    if(nameValue === '') {
        setError(name, 'Name is required');
        e.preventDefault();
    } else {
        setSuccess(name);
    }

    if(surnameValue === '') {
        setError(surname, 'Surname is required');
        e.preventDefault();
    } else {
        setSuccess(surname);
    }

    if(jobTitleValue === '') {
        setError(jobTitle, 'Job title is required');
        e.preventDefault();
    } else {
        setSuccess(jobTitle);
    }

    if(mobilePhoneValue === '') {
        setError(mobilePhone, 'Phone number is required');
        e.preventDefault();
    } 
    else if(!isValidPhoneNumber(mobilePhoneValue)){
        setError(mobilePhone, 'Phone number is not valid');
        e.preventDefault();
    }
    else {
        setSuccess(mobilePhone);
    }

};

const isValidPhoneNumber = phoneNumber => {
    const re = /^\+?(\d{1,3})?[-.\s]?\(?(\d{3})\)?[-.\s]?(\d{3})[-.\s]?(\d{4})$/;
    return re.test(String(phoneNumber));
}