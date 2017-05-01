$(document).ready(function () {
    if (model != null && model.LoginAsDemoUser) {
        var user = 'demouser';  //TODO - make constant
        var token = LoginDemoUser();
        SetLocalStorageBucketList(MOBILE_LOCAL_STORAGE_UserName, user);
        SetLocalStorageBucketList(MOBILE_LOCAL_STORAGE_Token, token);
    }

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