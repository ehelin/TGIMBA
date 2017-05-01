$(document).ready(function () {
    Initialize();
    Load();
});

function Initialize() {
    $("#Html5JqueryBody").hide();

    SessionClearStorage();
    SessionSetCategoryFilter(0);

    if (LocalStorageSupported() != TRUE)
        SessionSetLocalStorageSupported(DESKTOP_SESSION_clsLocalStorageSupportedKey, FALSE);
    else
        SessionSetLocalStorageSupported(DESKTOP_SESSION_clsLocalStorageSupportedKey, TRUE);
}
function Load() {
    LoadBucketItems();
    ApplyEventHandlers();
}
function LoadBucketItems() {
    var userName = GetLocalStorageBucketList(DESKTOP_LOCAL_STORAGE_UserName);
    var token = GetLocalStorageBucketList(DESKTOP_LOCAL_STORAGE_Token);
    var listItems = GetBucketList(userName, DESKTOP_SESSION_clsSortDesc, DESKTOP_SESSION_clsSortTypeKey, token, false);

    if (listItems != null) {
        ResetPageDivs();
        DisplayBucketList(listItems);
    }   
}

