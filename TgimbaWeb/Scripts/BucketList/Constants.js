var RANKING_OPTIONS = {
    HOT :'Hot',
    WARM : 'Warm',
    COLD : 'Cold'
}

var ONE = 1;

var TRUE = 'true';
var FALSE = 'false';

//local storage - mobile
var MOBILE_LOCAL_STORAGE_Token = 'BucketList_0001_Mobile_clsBucketList_ls_Token';
var MOBILE_LOCAL_STORAGE_UserName = 'BucketList_0001_Mobile_clsBucketList_ls_UserName';

//local storage - desktop
var DESKTOP_LOCAL_STORAGE_Token = 'BucketList_0001_Desktop_clsBucketList_ls_Token';
var DESKTOP_LOCAL_STORAGE_UserName = 'BucketList_0001_Desktop_clsBucketList_ls_UserName';

//Session - Mobile
var MOBILE_SESSION_clsSortDesc = "BucketList_0001_Mobile_Session_clsSortDesc";
var MOBILE_SESSION_clsSortTypeKey = "BucketList_0001_Mobile_Session_clsSortType";
var MOBILE_SESSION_clsLoadedStatusKey = "BucketList_0001_Mobile_Session_clsLoadedStatus";
var MOBILE_SESSION_clsMobileOrDesktopKey = "BucketList_0001_Mobile_Session_clsMobileOrDesktop";
var MOBILE_SESSION_clsSearchTermKey = "BucketList_0001_Mobile_Session_clsSearchTerm";
var MOBILE_SESSION_clsLocalStorageSupportedKey = "BucketList_0001_Mobile_Session_clsLocalStorageSupported";
var MOBILE_SESSION_clsEditIndexKey = "BucketList_0001_Mobile_Session_clsEditIndex";
var MOBILE_SESSION_clsBucketListKey = "BucketList_0001_Mobile_Session_clsBucketList";
var MOBILE_SESSION_clsBucketListKey = "BucketList_0001_Mobile_Session_clsBucketList";
var MOBILE_SESSION_clsLocalStorageSupportedKey = "BucketList_0001_Mobile_Session_clsLocalStorageSupported";
var MOBILE_SESSION_clsUserName = "BucketList_0001_Mobile_Session_clsUserName";
var MOBILE_SESSION_clsToken = "BucketList_0001_MOBILE_SESSION_clsToken";
var MOBILE_SESSION_STORAGE = 'BucketList_0001_Mobile_Session';

//Session - Desktop
var DESKTOP_SESSION_clsSortDesc = "BucketList_0001_Desktop_Session_clsSortDesc";
var DESKTOP_SESSION_clsSortTypeKey = "BucketList_0001_Desktop_Session_clsSortType";
var DESKTOP_SESSION_clsLoadedStatusKey = "BucketList_0001_Desktop_Session_clsLoadedStatus";
var DESKTOP_SESSION_clsMobileOrDesktopKey = "BucketList_0001_Desktop_Session_clsMobileOrDesktop";
var DESKTOP_SESSION_clsSearchTermKey = "BucketList_0001_Desktop_Session_clsSearchTerm";
var DESKTOP_SESSION_clsLocalStorageSupportedKey = "BucketList_0001_Desktop_Session_clsLocalStorageSupported";
var DESKTOP_SESSION_clsEditIndexKey = "BucketList_0001_Desktop_Session_clsEditIndex";
var DESKTOP_SESSION_clsBucketListKey = "BucketList_0001_Desktop_Session_clsBucketList";
var DESKTOP_SESSION_clsEditIndexKey = "BucketList_0001_Desktop_Session_clsEditIndex";
var DESKTOP_SESSION_clsLocalStorageSupportedKey = "BucketList_0001_Desktop_Session_clsLocalStorageSupported";
var DESKTOP_SESSION_clsCategoryFilter = "BucketList_0001_Desktop_Session_clsCategoryFilter";
var DESKTOP_SESSION_clsUserName = "BucketList_0001_Desktop_Session_clsUserName";
var DESKTOP_SESSION_clsToken = "BucketList_0001_DESKTOP_SESSION_clsToken";
var DESKTOP_SESSION_STORAGE = 'BucketList_0001_Desktop_Session';

var DIRECTION_SERVER = 'server';
var DIRECTION_CLIENT = 'client';

var TRUE = 'true';
var FALSE = 'false';

var SORTING_OPTIONS = {
    TITLE: 'ListItemName',
    RANKING: 'Category',
    ACHIEVED: 'Achieved',
    ENTERED: 'Created',
    CLEAR: 'Clear'
}

var ERROR_0001 = 'Sort Asc Desc cb is null - ';
var ERROR_0002 = 'Unknown sorting column';
var ERROR_000003 = 'Unable to set bucket list to local storage';
var ERROR_000004 = 'No item item found';
var ERROR_000005 = 'Data not being set to local storage';
var ERROR_000006 = 'No user name in session';
var ERROR_000007 = 'Token Expired';

var LOCAL_STORAGE = "localStorage";

var LOGIN_FORM = ' <table  class="LoginDisplayTable">  '
    + '                <tr class="LoginDisplayTable">  '
    + '                    <td class="BLItemCellParentTdRight">User Name:</td>  '
    + '                    <td class="BLItemCellParentTdLeft">  '
    + '                        <input type="text" id="loginDesktopUserName" name="loginDesktopUserName" class="BLItemCell" />  '
    + '                    </td>  '
    + '                  </tr>  '
    + '                  <tr class="LoginDisplayTable">  '
    + '                    <td class="BLItemCellParentTdRight">Password:</td>  '
    + '                    <td class="BLItemCellParentTdLeft">  '
    + '                        <input type="password" id="loginDesktopPassWord" name="loginDesktopPassWord" class="BLItemCell" />  '
    + '                    </td>  '
    + '                  </tr>  '
    + '              </table>  '
    + '              <table  class="LoginDisplayTable">  '
    + '                 <tr>  '
    + '                    <td  class="LoginButtons">  '
    + '                      <input type=\"button\" class=\"BLButtonMenu\" value=\"Submit\" id="loginDesktopSubmitClick" name="loginDesktopSubmitClick"/>'
    + '                    </td> '
    + '                 </tr> '
    + '                 <tr>   '
    + '                   <td  class="LoginButtons">  '
    + '                      <input type=\"button\" class=\"BLButtonMenu\" value=\"Register\" id="registerDesktopClick" name="registerDesktopClick"/>'
    + '                    </td>  '
    + '                 </tr>  '
    + '             </table>  '
    + '   <br/><center><a href="http://www.tgimba.com/WebRequest/WelcomePage">Home</a></center>';

var REGISTRATION_FORM = ' <table  class="LoginDisplayTable">  '
        + '                <tr class="LoginDisplayTable">  '
        + '                    <td class="BLItemCellParentTdRight">User Name:</td>  '
        + '                    <td class="BLItemCellParentTdLeft">  '
        + '                        <input type="text" id="registerDesktopUserName" name="registerDesktopUserName" class="BLItemCell" />  '
        + '                    </td>  '
        + '                  </tr>  '
        + '                  <tr class="LoginDisplayTable">  '
        + '                    <td class="BLItemCellParentTdRight">Email:</td>  '
        + '                    <td class="BLItemCellParentTdLeft">  '
        + '                        <input type="text" id="registerDesktopEmail" name="registerDesktopEmail" class="BLItemCell" />  '
        + '                    </td>  '
        + '                  </tr>  '
        + '                  <tr class="LoginDisplayTable">  '
        + '                    <td class="BLItemCellParentTdRight">Password:</td>  '
        + '                    <td class="BLItemCellParentTdLeft">  '
        + '                        <input type="password" id="registerDesktopPassword" name="registerDesktopPassword" class="BLItemCell" />  '
        + '                    </td>  '
        + '                  </tr>  '
        + '                  <tr class="LoginDisplayTable">  '
        + '                    <td class="BLItemCellParentTdRight">Confirm Password:</td>  '
        + '                    <td class="BLItemCellParentTdLeft">  '
        + '                        <input type="password" id="registerDesktopConfirmPassword" name="registerDesktopConfirmPassword" class="BLItemCell" />  '
        + '                    </td>  '
        + '                  </tr>  '
        + '              </table>  '
        + '              <table  class="LoginDisplayTable">  '
        + '                 <tr>  '
        + '                    <td  class="LoginButtons">  '
        + '                      <input type=\"button\" class=\"BLButtonMenu\" value=\"Submit\" id="registerDesktopSubmitClick" name="registerDesktopSubmitClick"/>'
        + '                    </td> '
        + '                 </tr> '
        + '                 <tr>   '
        + '                   <td  class="LoginButtons">  '
        + '                      <input type=\"button\" class=\"BLButtonMenu\" value=\"Cancel\" id="registerDesktopCancel" name="registerDesktopCancel"/>'
        + '                    </td>  '
        + '                 </tr>  '
        + '             </table>  ';

var ADD_ITEM_FORM = ' <div class="AddItemDisplay" id="AddItemDisplay" name="AddItemDisplay"> '
        + '     <div id="BucketListRecordId" class="hiddenField" name="BucketListRecordId"> '
        + '          <input type="text" id="BucketListRecordId" name="BucketListRecordId" />  '
        + '      </div>  '
        + '      <div name="BucketListItemDisplay" id="BucketListItemDisplay">  '
        + '          <table class="BucketListItemDisplayTable">  '
        + '              <tr>  '
        + '                  <td class="BLItemCellParentTdRight">Name</td>  '
        + '                  <td class="BLItemCellParentTdLeft">  '
        + '                      <input type="text" id="BIItemName" name="BIItemName" class="BLItemCell" />  '
        + '                  </td>  '
        + '              </tr>  '
        + '              <tr>  '
        + '                  <td class="BLItemCellParentTdRight">Date:</td>  '
        + '                  <td class="BLItemCellParentTdLeft">  '
        + '                      <script type="text/javascript">GetDateTime();</script>  '
        + '                      <input type="text" id="BLIDateTime" name="BLIDateTime" class="BLItemCell" readonly />  '
        + '                  </td>  '
        + '              </tr>  '
        + '              <tr>  '
        + '                  <td class="BLItemCellParentTdRight">Ranking</td>  '
        + '                  <td class="BLItemCellParentTdLeft">  '
        + '                      <div id="RankingCategoryInput" name="RankingCategoryInput" />  '
        + '                  </td>  '
        + '              </tr>  '
        + '              <tr>  '
        + '                  <td class="BLItemCellParentTdRight">Achieved</td>  '
        + '                  <td class="BLItemCellParentTdLeft">  '
        + '                      <div id="AchievedInput" name="AchievedInput" />  '
        + '                  </td>  '
        + '              </tr>  '
        + '              <tr>  '
        + '                  <td class="BLItemCellParentTdRight">Latitude</td>  '
        + '                  <td class="BLItemCellParentTdLeft">  '
        + '                      <input type="text" id="BILatitude" name="BILatitude" class="BLItemCell" />  '
        + '                  </td>  '
        + '              </tr>  '
        + '              <tr>  '
        + '                  <td class="BLItemCellParentTdRight">Longitude</td>  '
        + '                  <td class="BLItemCellParentTdLeft">  '
        + '                      <input type="text" id="BILongitude" name="BILongitude" class="BLItemCell" />  '
        + '                  </td>  '
        + '              </tr>  '
        + '              <tr>  '
        + '                  <td colspan="2">  '
        + '                      <div class="AddBIButtons" name="AddBIButtons" id="AddBIButtons">  '
        + '                          <input type="button" class="BLButtonMenu" value="Submit Add" id="AddBIButtonSubmit" name="AddBIButtonSubmit" />  '
        + '                      </div>  '
        + '                  </td>  '
        + '               </tr>  '
        + '               <tr id="EditRowTR" name="EditRowTR">  '
        + '                  <td colspan="2">  '
        + '                      <div class="EditBIButtons" name="EditBIButtons" id="EditBIButtons">  '
        + '                          <input type="button" class="BLButtonMenu" value="Submit Edit" id="EditBIButtonSubmit" name="EditBIButtonSubmit" />  '
        + '                      </div>  '
        + '                  </td>  '
        + '              </tr>  '
        + '          </table>  '
        + '      </div>  '
        + '  </div>   ';

