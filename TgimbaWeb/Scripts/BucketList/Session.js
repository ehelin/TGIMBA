//session sort description type ---------------------------------------------
function SessionSetSortDesc(clsSortDescKey, value) {  
    SetSessionItem(clsSortDescKey, value);
}
function SessionGetSortDesc(clsSortDescKey) {
    var val = sessionStorage.getItem(clsSortDescKey);
    return val;
}

//token ------------------------------------------------------------------
function SessionSetToken(clsSortDescKey, value) {
    SetSessionItem(clsSortDescKey, value);
}
function SessionGetToken(clsSortDescKey) {
    var val = sessionStorage.getItem(clsSortDescKey);
    return val;
}

//username ------------------------------------------------------------------
function SessionSetUserName(clsSortDescKey, value) {
    SetSessionItem(clsSortDescKey, value);
}
function SessionGetUserName(clsSortDescKey) {
    var val = sessionStorage.getItem(clsSortDescKey);
    return val;
}

//category setting (desktop only) --------------------------------------------
function SessionSetCategoryFilter(value) {
    SetSessionItem(DESKTOP_SESSION_clsCategoryFilter, value);
}
function SessionGetCategoryFilter() {
    var val = sessionStorage.getItem(DESKTOP_SESSION_clsCategoryFilter);
    return val;
}

//session sort type key ------------------------------------------------------
function SessionSetSortType(clsSortTypeKey, value) {
    SetSessionItem(clsSortTypeKey, value);
}
function SessionGetSortType(clsSortTypeKey) {
    var val = sessionStorage.getItem(clsSortTypeKey);
    return val;
}

//session search -------------------------------------------------------
function SessionSetSearchTerm(clsSearchTermKey, value) {
    SetSessionItem(clsSearchTermKey, value);
}
function SessionGetSearchTerm(clsSearchTermKey) {
    var val = sessionStorage.getItem(clsSearchTermKey);
    return val;
}

//session local storage supported --------------------------------------------
function SessionSetLocalStorageSupported(clsLocalStorageSupportedKey, value) {
    SetSessionItem(clsLocalStorageSupportedKey, value);
}
function SessionGetLocalStorageSupported(clsLocalStorageSupportedKey) {
    var val = sessionStorage.getItem(clsLocalStorageSupportedKey);
    return val;
}

//session Edit index  --------------------------------------------------------
function SessionSetEditIndex(clsEditIndexKey, value) {
    SetSessionItem(clsEditIndexKey, value);
}
function SessionGetEditIndex(clsEditIndexKey) {
    var val = sessionStorage.getItem(clsEditIndexKey);
    return val;
}

//session bucket list ---------------------------------------------------------
function SessionSetBucketList(clsBucketListKey, value) {
    SetSessionItem(clsBucketListKey, value);
}
function SessionGetBucketList(clsBucketListKey, split) {
    var val = sessionStorage.getItem(clsBucketListKey);
    if (val != null && split != null && split == 'true')
        val = val.split(';');

    return val;
}

//misc --------------------------------------------------------
function SessionClearStorage() {
    sessionStorage.clear();
}
function SetSessionItem(key, value) {
    sessionStorage.setItem(key, value);
}