$(document).ready(function () {
    Initialize()
    Load();
});

function Initialize() {
    $("#Html5JqueryBody").hide();

    SessionClearStorage();

    if (LocalStorageSupported() != TRUE)
        SessionSetLocalStorageSupported(MOBILE_SESSION_clsLocalStorageSupportedKey, FALSE);
    else
        SessionSetLocalStorageSupported(MOBILE_SESSION_clsLocalStorageSupportedKey, TRUE);
}
function Load() {
    LoadBucketItems();
    ApplyEventHandlers();
}
function LoadBucketItems() {
    var userName = GetLocalStorageBucketList(MOBILE_LOCAL_STORAGE_UserName);
    var token = GetLocalStorageBucketList(MOBILE_LOCAL_STORAGE_Token);
    var listItems = GetBucketList(userName, MOBILE_SESSION_clsSortDesc, MOBILE_SESSION_clsSortTypeKey, token, true);

    if (listItems != null) {
        ResetPageDivs();
        DisplayBucketList(listItems);
    }
}