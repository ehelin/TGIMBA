function ApplyEventHandlers() {
    //menu screen events
    $("#MenuRequest").unbind("click").bind("click", ShowMenuClick);
    $("#CancelMenuDisplay").unbind("click").bind("click", GlobalCancelEventClick);
    $("#AddBucketListItem").unbind("click").bind("click", AddBucketListItemClick);
    $("#SortBucketListItem").unbind("click").bind("click", SortBucketListItemClick);
    $("#LogOut").unbind("click").bind("click", LogoutItemClick);
    $("#TravelingSalesman").unbind("click").bind("click", TravelingSalesmanClick);

    //algorithm
    $("#CancelAlgorithmDisplay").unbind("click").bind("click", GlobalCancelEventClick);

    //add bi screen events
    $("#CancelAddItemDisplay").unbind("click").bind("click", GlobalCancelEventClick);

    //edit screen events
    $("#EditBIButtonSubmit").unbind("click").bind("click", EditBIButtonSubmitClick);

    //search events
    $("#searchButtonRequest").unbind("click").bind("click", SearchButtonRequestClick);
    $("#CancelSearchResultsDisplay").unbind("click").bind("click", GlobalCancelEventClick);
    $("#searchButtonSubmit").unbind("click").bind("click", SearchButtonSubmitClick);

    //login
    $("#loginDesktopSubmitClick").unbind("click").bind("click", LoginButtonSubmitClick);
    $("#registerDesktopClick").unbind("click").bind("click", registerDesktopClick);
    $("#registerDesktopSubmitClick").unbind("click").bind("click", registerDesktopSubmitClick);
    $("#registerDesktopCancel").unbind("click").bind("click", registerDesktopCancel);
}

//Login Events ---------------------------------------
function registerDesktopSubmitClick() {    
    var userName = $("#registerDesktopUserName").val();
    var email = $("#registerDesktopEmail").val();
    var passWord = $("#registerDesktopPassword").val();
    var confirmPassWord = $("#registerDesktopConfirmPassword").val();
    var registrationMsg = ValidateGoodRegistrationValues(userName, email, passWord, confirmPassWord);

    if (registrationMsg != null)
        alert(registrationMsg);
    else {
        var userCreated = Register(userName, email, passWord);

        if (userCreated == true) {
            alert('Registeration succeeded!  Please login now');
            DisplayDesktopLogin();
        }
        else {
            alert('Registeration failed.  Please make sure all fields are filled and that the username has not already been used');
        }
    }

    ApplyEventHandlers();
}
function registerDesktopCancel() {
    DisplayDesktopLogin();
    ApplyEventHandlers();
}
function registerDesktopClick() {
    DisplayDesktopRegistration();
    ApplyEventHandlers();
}
function LoginButtonSubmitClick() {
    var userName = $("#loginDesktopUserName").val();
    var passWord = $("#loginDesktopPassWord").val();

    if (userName == null || userName == '' || passWord == null || passWord == '') {
        alert("Please enter a username and password");
    }
    else {
        var token = ProcessLogin(userName, passWord);

        if (token != null && token.length > 0) {
            var listItems = GetBucketList(userName, DESKTOP_SESSION_clsSortDesc, DESKTOP_SESSION_clsSortTypeKey, token, false);

            SetLocalStorageBucketList(DESKTOP_LOCAL_STORAGE_UserName, userName);
            SetLocalStorageBucketList(DESKTOP_LOCAL_STORAGE_Token, token);

            ResetPageDivs();
            if (listItems != null && listItems[0] != 'No Items')
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
function GlobalCancelEventClick() {
    ResetPageDivs();
}
function AddBucketListItemClick() {
    ResetPageDivs();
    DisplayAddBIForm();
}
function SortBucketListItemClick() {
    DisplayPage("SortBucketListOptions");
}
function LogoutItemClick() {
    GlobalLogout();
    DisplayDesktopLogin();
    ApplyEventHandlers();
}
function TravelingSalesmanClick() {
    $("#MenuDisplay").hide();
    $("#TravelingSalespersonList").show();
}

//Add BI Events ---------------------------------------
function AddBIButtonSubmitClick() {
    var userName = GetLocalStorageBucketList(DESKTOP_LOCAL_STORAGE_UserName);
    var newInput = GetBucketListInput(0, userName);

    if (newInput != null && newInput != 'null' && newInput != '') {
        var token = GetLocalStorageBucketList(DESKTOP_LOCAL_STORAGE_Token);
        var result = UpsertBucketListItem(newInput, userName, token, false);

        if (result != null) {
            var listItems = GetBucketList(userName, DESKTOP_SESSION_clsSortDesc, DESKTOP_SESSION_clsSortTypeKey, token, false);

            if (listItems != null) {
                ResetPageDivs();
                DisplayBucketList(listItems);

                $("#AddBucketListItem").unbind("click").bind("click", AddBucketListItemClick);
            }
        }
    }
}

//Edit BI events ----------------------------------------
function ProcessEdit(index) {
    var item = GetBucketListItemEvent(index);

    if (item != null && item != '') {
        if (item.substring(0, 1) != ',')
            item = ',' + item;

        ResetPageDivs();
        DisplayEditDesktopBIForm(item, index, true);
        SessionSetEditIndex(DESKTOP_SESSION_clsEditIndexKey, index);

        $("#AddBucketListItem").unbind("click").bind("click", AddBucketListItemClick);
    }
}
function GetBucketListItemEvent(index) {
    var userName = GetLocalStorageBucketList(DESKTOP_LOCAL_STORAGE_UserName);
    var token = GetLocalStorageBucketList(DESKTOP_LOCAL_STORAGE_Token);    
    var listItems = GetBucketList(userName, DESKTOP_SESSION_clsSortDesc, DESKTOP_SESSION_clsSortTypeKey, token, false);
    var item = null;

    if (listItems != null) {
        var item = GetBucketListItem(listItems, index);
    }

    return item;
}
function ProcessEditDetail(index) {
    var item = GetBucketListItemEvent(index);
    
    if (item != null && item != '') {
        if (item.substring(0, 1) != ',')
            item = ',' + item;

        ResetPageDivs();
        DisplayEditBIForm(item, index);
        SessionSetEditIndex(DESKTOP_SESSION_clsEditIndexKey, index);

        $("#AddBucketListItem").unbind("click").bind("click", AddBucketListItemClick);
    }
}
function EditBIButtonSubmitClick() {
    var editIndex = SessionGetEditIndex(DESKTOP_SESSION_clsEditIndexKey);
    if (editIndex == null)
        alert("Error: Edit index is null");
    else {
        var userName = GetLocalStorageBucketList(DESKTOP_LOCAL_STORAGE_UserName);
        var token = GetLocalStorageBucketList(DESKTOP_LOCAL_STORAGE_Token);
        var newInput = GetBucketListInput(editIndex, userName);

        var result = UpsertBucketListItem(newInput, userName, token, false);

        if (result != null) {
            var listItems = GetBucketList(userName, DESKTOP_SESSION_clsSortDesc, DESKTOP_SESSION_clsSortTypeKey, token, false);

            if (listItems != null) {
                ResetPageDivs();
                DisplayBucketList(listItems);

                $("#AddBucketListItem").unbind("click").bind("click", AddBucketListItemClick);
            }
        }
    }
}

//delete events -----------------------------------------
function ProcessDelete(index) {
    var userName = GetLocalStorageBucketList(DESKTOP_LOCAL_STORAGE_UserName);
    var token = GetLocalStorageBucketList(DESKTOP_LOCAL_STORAGE_Token);
    var result = DeleteBucketListItem(index, userName, token, false);

    if (result != null) {
        var listItems = GetBucketList(userName, DESKTOP_SESSION_clsSortDesc, DESKTOP_SESSION_clsSortTypeKey, token, false);

        ResetPageDivs();
        DisplayBucketList(listItems);

        $("#AddBucketListItem").unbind("click").bind("click", AddBucketListItemClick);
    }
}

//category events ---------------------------------------
function ProcessCategoryFilterEdit(index) {
    var userName = GetLocalStorageBucketList(DESKTOP_LOCAL_STORAGE_UserName);
    var token = GetLocalStorageBucketList(DESKTOP_LOCAL_STORAGE_Token);
    var listItems = GetBucketList(userName, DESKTOP_SESSION_clsSortDesc, DESKTOP_SESSION_clsSortTypeKey, token, false);
    
    if (listItems != null) {
        SessionSetCategoryFilter(index);
        ResetPageDivs();
        DisplayBucketList(listItems);
    }
}

//search events -----------------------------------------
function SearchButtonRequestClick() {
    DisplayPage("SearchItemDisplay");
    DisplaySearchCriteria('true');
}
function SearchButtonSubmitClick() {
    EventSearch();
}
function EventSearch() {
    var userName = GetLocalStorageBucketList(DESKTOP_LOCAL_STORAGE_UserName);
    var token = GetLocalStorageBucketList(DESKTOP_LOCAL_STORAGE_Token);
    var results = PerformSearch(DESKTOP_SESSION_clsSortDesc, DESKTOP_SESSION_clsSortTypeKey, DESKTOP_SESSION_clsSearchTermKey, userName, token, false);

    ResetPageDivs();

    if (results != null && results != 'undefined' && results != '') {
        DisplaySearchResultsMobile(results);
    }
    else {
        var listItems = GetBucketList(userName, DESKTOP_SESSION_clsSortDesc, DESKTOP_SESSION_clsSortTypeKey, token, false);
        
        if (listItems != null) {
            ResetPageDivs();
            DisplayBucketList(listItems);
        }
    }

    $("#AddBucketListItem").unbind("click").bind("click", AddBucketListItemClick);
}
function ProcessSort(SortOperation) {
    if (SortOperation != SORTING_OPTIONS.CLEAR) {
        var desc = GetSortDescAscValue(DESKTOP_SESSION_STORAGE);

        SessionSetSortDesc(DESKTOP_SESSION_clsSortDesc, desc);
        SessionSetSortType(DESKTOP_SESSION_clsSortTypeKey, SortOperation);
    }
    else {
        SessionSetSortDesc(DESKTOP_SESSION_clsSortDesc, null);
        SessionSetSortType(DESKTOP_SESSION_clsSortTypeKey, null);
    }

    var userName = GetLocalStorageBucketList(DESKTOP_LOCAL_STORAGE_UserName);
    var token = GetLocalStorageBucketList(DESKTOP_LOCAL_STORAGE_Token);
    var listItems = GetBucketList(userName, DESKTOP_SESSION_clsSortDesc, DESKTOP_SESSION_clsSortTypeKey, token, false);

    if (listItems != null) {
        ResetPageDivs();
        DisplayBucketList(listItems);
    }
}