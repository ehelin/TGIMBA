function ApplyEventHandlers() {
    //menu screen events
    $("#MenuRequest").unbind("click").bind("click", ShowMenuClick);
    $("#CancelMenuDisplay").unbind("click").bind("click", GlobalCancelEventClick);
    $("#AddBucketListItem").unbind("click").bind("click", AddBucketListItemClick);
    $("#SortBucketListItem").unbind("click").bind("click", SortBucketListItemClick);
    $("#LogOut").unbind("click").bind("click", LogoutItemClick);

    //add bi screen events
    $("#CancelAddItemDisplay").unbind("click").bind("click", GlobalCancelEventClick);
    $("#AddBIButtonSubmit").unbind("click").bind("click", AddBIButtonSubmitClickEvent);

    //edit screen events
    $("#EditBIButtonSubmit").unbind("click").bind("click", EditBIButtonSubmitClick);
    $("#searchButtonRequest").unbind("click").bind("click", SearchButtonRequestClick);
    $("#searchButtonSubmit").unbind("click").bind("click", SearchButtonSubmitClick);

    //login
    $("#loginDesktopSubmitClick").unbind("click").bind("click", LoginButtonSubmitClick);
    $("#registerDesktopClick").unbind("click").bind("click", registerMobileClick);
    $("#registerDesktopSubmitClick").unbind("click").bind("click", registerMobileSubmitClick);
    $("#registerDesktopCancel").unbind("click").bind("click", registerMobileCancel);

    //search
    $("#CancelSearchResultDisplay").unbind("click").bind("click", GlobalCancelEventClick);
}

//Login -----------------------------------------------
function registerMobileSubmitClick() {
    var userName = $("#registerDesktopUserName").val();
    var email = $("#registerDesktopEmail").val();
    var passWord = $("#registerDesktopPassword").val();
    var confirmPassWord = $("#registerDesktopConfirmPassword").val();
    var registrationMsg = ValidateGoodRegistrationValues(userName, email, passWord, confirmPassWord);

    if (registrationMsg != null)
        alert(registrationMsg);
    else {
        var userCreated = Register(userName, email, passWord);

        //TODO - add validation for each field type
        if (userCreated == true) {
            alert('Registeration succeeded!  Please login now');
            DisplayMobileLogin();
        }
        else {
            alert('Registeration failed.  Please make sure all fields are filled and that the username has not already been used');
        }
    }

    ApplyEventHandlers();
}
function registerMobileCancel() {
    DisplayMobileLogin();
    ApplyEventHandlers();
}
function registerMobileClick() {
    DisplayMobileRegistration();
    ApplyEventHandlers();
}
function LogoutItemClick() {
    GlobalLogout();
    DisplayMobileLogin();
    ApplyEventHandlers();
}
function LoginButtonSubmitClick() {
    var userName = $("#loginDesktopUserName").val();
    var passWord = $("#loginDesktopPassWord").val();

    if (userName == null || userName == '' || passWord == null || passWord == '')
        alert("Please enter a username and password");
    else {
        var token = ProcessLogin(userName, passWord);

        if (token != null && token.length > 0) {
            var listItems = GetBucketList(userName, MOBILE_SESSION_clsSortDesc, MOBILE_SESSION_clsSortTypeKey, token, true);

            SetLocalStorageBucketList(MOBILE_LOCAL_STORAGE_UserName, userName);
            SetLocalStorageBucketList(MOBILE_LOCAL_STORAGE_Token, token);

            ResetPageDivs();
            if (listItems != null)
                DisplayBucketList(listItems);
        }
        else {
            $("#loginDesktopPassWord").val('');
            alert('Error: Username/Password are not found or are not correct');
        }
    }

    ApplyEventHandlers();
}

//Menu Events ------------------------------------------
function ShowMenuClick() {
    DisplayPage("MenuDisplay");
}
function SearchCancelEventClick() {
    GlobalCancelEventClick();
}
function ShowMenuClick() {
    DisplayPage("MenuDisplay");
}
function GlobalCancelEventClick() {
    ResetPageDivs();
}
function AddBucketListItemClick() {
    DisplayPage("AddItemDisplay");
    DisplayAddBIForm('true');
}
function SortBucketListItemClick() {
    DisplayPage("SortBucketListOptions");
}

//Add Bucket item events ----------------------------------
function AddBIButtonSubmitClickEvent() {
    AddBIButtonSubmitClick();
}
function AddBIButtonSubmitClick() {
    var userName = GetLocalStorageBucketList(MOBILE_LOCAL_STORAGE_UserName);
    var newInput = GetBucketListInput(0, userName);

    if (newInput != null && newInput != 'null' && newInput != '') {
        var token = GetLocalStorageBucketList(MOBILE_LOCAL_STORAGE_Token);
        var result = UpsertBucketListItem(newInput, userName, token, true);

        if (result != null) {
            var listItems = GetBucketList(userName, MOBILE_SESSION_clsSortDesc, MOBILE_SESSION_clsSortTypeKey, token, true);

            if (listItems != null) {
                ResetPageDivs();
                DisplayBucketList(listItems);

                $("#AddBucketListItem").unbind("click").bind("click", AddBucketListItemClick);
            }
        }
    }
    ApplyEventHandlers();
}

//edit events -------------------------------------------------------
function ProcessEdit(index) {
    var item = GetBucketListItemEvent(index);

    if (item != null && item != '') {
        if (item.substring(0, 1) != ',')
            item = ',' + item;

        ResetPageDivs();
        DisplayEditBIForm(item);
        SessionSetEditIndex(MOBILE_SESSION_clsEditIndexKey, index);

        $("#AddBucketListItem").unbind("click").bind("click", AddBucketListItemClick);
    }
    ApplyEventHandlers();
}
function GetBucketListItemEvent(index) {
    var userName = GetLocalStorageBucketList(MOBILE_LOCAL_STORAGE_UserName);
    var token = GetLocalStorageBucketList(MOBILE_LOCAL_STORAGE_Token);
    var listItems = GetBucketList(userName, MOBILE_SESSION_clsSortDesc, MOBILE_SESSION_clsSortTypeKey, token, false);
    var item = null;

    if (listItems != null) {
        var item = GetBucketListItem(listItems, index);
    }

    return item;
}
function EditBIButtonSubmitClick() {
    var editIndex = SessionGetEditIndex(MOBILE_SESSION_clsEditIndexKey);
    if (editIndex == null)
        alert("Error: Edit index is null");
    else {
        var userName = GetLocalStorageBucketList(MOBILE_LOCAL_STORAGE_UserName);
        var token = GetLocalStorageBucketList(MOBILE_LOCAL_STORAGE_Token);
        var newInput = GetBucketListInput(editIndex, userName);

        var result = UpsertBucketListItem(newInput, userName, token, false);

        if (result != null) {
            var listItems = GetBucketList(userName, MOBILE_SESSION_clsSortDesc, MOBILE_SESSION_clsSortTypeKey, token, true);

            if (listItems != null) {
                ResetPageDivs();
                DisplayBucketList(listItems);

                $("#AddBucketListItem").unbind("click").bind("click", AddBucketListItemClick);
            }
        }
    }
    ApplyEventHandlers();
}

//delete events ----------------------------------------------
function ProcessDelete(index) {
    var userName = GetLocalStorageBucketList(MOBILE_LOCAL_STORAGE_UserName);
    var token = GetLocalStorageBucketList(MOBILE_LOCAL_STORAGE_Token);
    var result = DeleteBucketListItem(index, userName, token, false);

    if (result != null) {
        var listItems = GetBucketList(userName, MOBILE_SESSION_clsSortDesc, MOBILE_SESSION_clsSortTypeKey, token, true);

        ResetPageDivs();
        DisplayBucketList(listItems);

        $("#AddBucketListItem").unbind("click").bind("click", AddBucketListItemClick);
    }
    ApplyEventHandlers();
}

//search events -----------------------------------------------
function SearchButtonRequestClick() {
    DisplayPage("SearchItemDisplay");
    DisplaySearchCriteria('true');
    ApplyEventHandlers();
}
function SearchButtonSubmitClick() {
    EventSearch();
}
function EventSearch() {
    var userName = GetLocalStorageBucketList(MOBILE_LOCAL_STORAGE_UserName);
    var token = GetLocalStorageBucketList(MOBILE_LOCAL_STORAGE_Token);
    var results = PerformSearch(MOBILE_SESSION_clsSortDesc, MOBILE_SESSION_clsSortTypeKey, MOBILE_SESSION_clsSearchTermKey, userName, token, true);

    ResetPageDivs();

    if (results != null && results != 'undefined' && results != '') {
        DisplaySearchResultsMobile(results);
    }
    else {
        var listItems = GetBucketList(userName, MOBILE_SESSION_clsSortDesc, MOBILE_SESSION_clsSortTypeKey, token, false);

        if (listItems != null) {
            ResetPageDivs();
            DisplayBucketList(listItems);
        }
    }

    $("#AddBucketListItem").unbind("click").bind("click", AddBucketListItemClick);
}
function ProcessSearchEdit(index) {
    ProcessEdit(index)
}
function ProcessSearchDelete(index) {
    var userName = GetLocalStorageBucketList(MOBILE_LOCAL_STORAGE_UserName);
    var token = GetLocalStorageBucketList(MOBILE_LOCAL_STORAGE_Token);
    var result = DeleteBucketListItem(index, userName, token, true);

    if (result != null) {
        var listItems = GetBucketList(userName, MOBILE_SESSION_clsSortDesc, MOBILE_SESSION_clsSortTypeKey, token, true);

        ResetPageDivs();
        DisplayBucketList(listItems);

        $("#AddBucketListItem").unbind("click").bind("click", AddBucketListItemClick);
    }
    ApplyEventHandlers();
}
function ProcessSort(SortOperation) {
    if (SortOperation != SORTING_OPTIONS.CLEAR) {
        var desc = GetSortDescAscValue(MOBILE_SESSION_STORAGE);

        SessionSetSortDesc(MOBILE_SESSION_clsSortDesc, desc);
        SessionSetSortType(MOBILE_SESSION_clsSortTypeKey, SortOperation);
    }
    else {
        SessionSetSortDesc(MOBILE_SESSION_clsSortDesc, null);
        SessionSetSortType(MOBILE_SESSION_clsSortTypeKey, null);
    }

    var userName = GetLocalStorageBucketList(MOBILE_LOCAL_STORAGE_UserName);
    var token = GetLocalStorageBucketList(MOBILE_LOCAL_STORAGE_Token);
    var listItems = GetBucketList(userName, MOBILE_SESSION_clsSortDesc, MOBILE_SESSION_clsSortTypeKey, token, true);

    if (listItems != null) {
        ResetPageDivs();
        DisplayBucketList(listItems);
    }
    ApplyEventHandlers();
}