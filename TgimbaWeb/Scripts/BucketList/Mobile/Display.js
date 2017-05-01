//display variables -------------------------------------------------------------------
var tblCellPrefix = '<td class="MobileBucketListCellRight">';
var tblCellPrefixLeftAlign = '<td class="MobileBucketListCellLeft">';
var tblCellPrefixCenter = '<td class="MobileBucketListCellCenter">';
var tblCellSuffix = '</td>';
var tblCellPrefixSearch = '<td class="MobileBucketListCellRightSearch">';
var tblCellPrefixLeftAlignSearch = '<td class="MobileBucketListCellLeftSearch">';
var tblCellPrefixCenterSearch = '<td class="MobileBucketListCellCenterSearch">';

//registration ----------------------------------------------------
function DisplayMobileRegistration() {
    var loginCntrl = $("#LoginDisplay");

    SetPageForLogin();
    loginCntrl.html('');

    var registerDisplay = REGISTRATION_FORM;

    loginCntrl.append(registerDisplay);
    loginCntrl.show();
}

//login ----------------------------------------------------
function DisplayMobileLogin() {
    var loginCntrl = $("#LoginDisplay");

    SetPageForLogin();
    loginCntrl.html('');

    var loginDisplay = LOGIN_FORM;

    loginCntrl.append(loginDisplay);
    loginCntrl.show();
}
function SetPageForLogin() {
    $("#ParentBody").show();
    $("#PageDisplay").show();
    $("#MenuDisplay").show();
    $("#OptionsDisplay").hide();
    $("#SearchResultsMobileDisplay").hide();
    $("#SortBucketListOptions").hide();
    $("#Html5JqueryBody").hide();
    $("#MenuRequestDisplay").hide();
    $("#HeaderLabel").hide();
    $("#Html5JqueryContentDiv").hide();
    $("#Html5JqueryFooter").hide();
    $("#Html5JqueryArticleContent").hide();
    $("#TravelingSalespersonList").hide();
    $("#DesktopCategoryFilter").hide();
    $("#LoginDisplay").hide();
    $("#MenuDisplay").hide();
    $("#Html5JqueryBody").hide();
    $("#MenuRequestDisplay").hide();
    $("#OptionsDisplay").hide();
    $("#SearchItemDisplay").hide();
    $("#SearchResultsDisplay").hide();
    $("#AddItemDisplay").hide();
    $("#MenuRequestDisplay").hide();
    $("#BucketListItemDisplay").hide();
    $("#AddBIButtons").hide();
    $("#EditBIButtons").hide();
    $("#SearchResultsMobileDisplay").hide();
    $("#MenuDisplay").hide();
    $("#Html5JqueryContentDiv").hide();
    $("#AddItemDesktopDisplay").hide();
    $("#BucketListItemDesktopDisplay").hide();
    $("#SearchTerm").val('');
    $("#SortBucketListOptions").html('');
    $("#SortBucketListOptions").hide();
    $("#BIItemName").val('');
    $("#BLIDateTime").val('');
    $("#BIRanking").val('');
    $("#BIAchieved").val('');
}

//edit bucket list item -----------------------------------
function DisplayEditBIForm(item) {
    ClearBIItemForm();
    var addBIDisplay = $("#BucketListItemDisplay"); //BucketListAddForm
    var data = item.split(',');

    //TODO - figure out good way to trim leading/trailing commas, use here and revert back to 0,1,2 etc.
    $("#BIItemName").val(data[1]);
    $("#BLIDateTime").val(data[2]);
    $("#RankingCategoryInput").html('');
    $("#RankingCategoryInput").append(GetRankingOptionsAsSelectHtml(data[3]));
    $("#AchievedInput").html('');
    $("#AchievedInput").append(GetItemAchievedAsCheckboxHtml(data[4]));
    $("#BILatitude").val(data[5]);
    $("#BILongitude").val(data[6]);

    $("#BucketListRecordId").val(data[7]); //TODO - make this dynamic so the record id is the last element

    DisplayPage("EditBIItem");
}

//Add bucket list item ------------------------------------
function DisplayAddBIForm() {
    ClearBIItemForm();
    var addBIDisplay = $("#BucketListItemDisplay");

    $("#BLIDateTime").val(GetDateTime());
    $("#RankingCategoryInput").html('');
    $("#RankingCategoryInput").append(GetRankingOptionsAsSelectHtml(null));
    $("#AchievedInput").html('');
    $("#AchievedInput").append(GetItemAchievedAsCheckboxHtml(null));

    addBIDisplay.show();
    $("#AddBIButtons").show();
}
function ClearBIItemForm() {
    $("#BIItemName").val('');
    $("#BLIDateTime").val('');
    $("#BIRanking").val('');
    $("#BIAchieved").val('');
    $("#BILatitude").val('');
    $("#BILongitude").val('');
}

//misc ----------------------------------------------------
function DisplayPage(PageToDisplay) {
    ResetPageDivs();

    if (PageToDisplay != null) {
        GlobalHide();

        if (PageToDisplay == "MenuDisplay") {
            $("#MenuDisplay").show();
        }

        else if (PageToDisplay == "OptionsDisplay") {
            $("#OptionsDisplay").show();
        }

        else if (PageToDisplay == "AddItemDisplay") {
            $("#AddItemDisplay").show();

            $("#CancelAddItemDisplay").click(GlobalCancelEventClick);
        }

        else if (PageToDisplay == "SearchItemDisplay") {
            $("#SearchItemDisplay").show();
        }

        else if (PageToDisplay == "SearchResultsMobileDisplay") {
            $("#SearchResultsMobileDisplay").show();
            $("#CancelSearchResultDisplay").click(SearchCancelEventClick);
        }

        else if (PageToDisplay == "EditBIItem") {
            $("#AddItemDisplay").show();
            $("#BucketListItemDisplay").show();
            $("#BucketListItemDisplayTable").show();
            $("#EditBIButtons").show();
            $("#CancelEditItemDisplay").click(GlobalCancelEventClick);
        }

        else if (PageToDisplay == "EditBIItemDesktop") {
            $("#AddItemDesktopDisplay").show();
            $("#BucketListItemDesktopDisplay").show();

            $("#CancelDesktopEditDisplay").click(GlobalCancelEventClick);
        }

        else if (PageToDisplay == "SortBucketListOptions") {
            $("#SortBucketListOptions").html('');
            $("#SortBucketListOptions").append(GetSortOptions());
            $("#SortBucketListOptions").show();
            $("#SplitBodyDisplay").hide();
        }

        $("#PageDisplay").show();
    }
    else
        $("#PageDisplay").show();
}
function ResetPage() {
    $("#BucketListItemDisplay").hide();
    $("#SearchDisplay").hide();
    $("#SearchCriteriaDisplay").hide();
    $("#SearchButtonDisplay").show();
    $("#SearchResultsDisplay").hide();
    $("#SearchCriteriaDisplay").hide();
    $("#AddBIButtons").hide();
    $("#EditBIButtons").hide();
    $("#SearchTerm").val('');
    $("#Html5JqueryContentDiv").show();
    ClearBIItemForm();
}
function ResetPageDivs() {
    $("#TravelingSalespersonList").hide();
    $("#Html5JqueryBody").show();
    $("#MenuRequestDisplay").hide();
    $("#OptionsDisplay").hide();
    $("#PageDisplay").hide();
    $("#SearchItemDisplay").hide();
    $("#SearchResultsDisplay").hide();
    $("#AddItemDisplay").hide();
    $("#MenuRequestDisplay").show();
    $("#BucketListItemDisplay").hide();
    $("#AddBIButtons").hide();
    $("#EditBIButtons").hide();
    $("#SearchResultsMobileDisplay").hide();
    $("#MenuDisplay").hide();
    $("#Html5JqueryContentDiv").show();
    $("#AddItemDesktopDisplay").hide();
    $("#BucketListItemDesktopDisplay").hide();
    $("#DesktopTest").hide();
    $("#SearchTerm").val('');
    $("#SortBucketListOptions").html('');
    $("#SortBucketListOptions").hide();
    $("#BucketListDisplay").show();
    $("#Html5JqueryArticleContent").show();
    $("#MenuSpan").show();
    $("#HeaderLabel").show();
    $("#LoginDisplay").html('');
    $("#LoginDisplay").show();
}
function GlobalHide()
{    
    $("#TravelingSalespersonList").hide();
    $("#Html5JqueryBody").hide();
    $("#SearchResultsDisplay").hide();
    $("#MenuDisplay").hide();
    $("#SearchResultsMobileDisplay").hide();
    $("#MenuRequestDisplay").hide();
    $("#SearchItemDisplay").hide();
}

//search ---------------------------------------------
function DisplaySearchResultsMobile(results) {
    var srchResultsDisplay = $("#SearchResultsMobileDisplay");
    var srchDisplay = $("#SearchDisplay");
    var dynamicTable = '<table class="SearchResultsDisplayMobileTable"><tbody>';

    srchResultsDisplay.html('');
    srchResultsDisplay.append('<p>Search Results:</p>');

    results = results.split(';');
    var indexCtr = 1;
    for (var i = 0; i < results.length; i++) {
        var curResult = results[i];

        if (curResult == null || curResult == '' || curResult == ',')
            break;

        curResult = ',' + curResult;
        curResult = curResult.split(',');

        dynamicTable = AddSearchRow(dynamicTable, curResult, 'true', i);
        indexCtr = indexCtr + 1;
    }

    dynamicTable = dynamicTable + '</tbody></table>';
    dynamicTable = dynamicTable + '<input type=\"button\" class=\"BLButtonMenu\" value=\"Cancel\" id="CancelSearchResultDisplay" name="CancelSearchResultDisplay"/>';
    dynamicTable = dynamicTable + '<br/><br/>';

    srchResultsDisplay.append(dynamicTable);

    DisplayPage("SearchResultsMobileDisplay");
}
function AddSearchRow(dynamicTable, results, addButtons, index) {
    dynamicTable = dynamicTable + '<tr>';
    var eventIndex = results[results.length - 1];
    var endIndexExit = 0;

    if (addButtons == 'true')
        endIndexExit = results.length - 1;
    else
        endIndexExit = results.length;

    for (var i = 0; i < endIndexExit; i++) {
        var curResult = results[i];
        curResult = curResult.replace(";", "");

        if (addButtons == 'true' && i == 0) {
            var editBtn = "<input type=\"button\" id=\"btnSearchEdit" + index + "\" name=\"btnSearchEdit" + index + "\" class=\"BLButtonEditSearch\" onclick=\"ProcessSearchEdit(" + eventIndex + ")\"/>";
            var deleteBtn = "<input type=\"button\" id=\"btnSearchDelete" + index + "\" name=\"btnSearchDelete" + index + "\"class=\"BLButtonDeleteSearch\" onclick=\"ProcessSearchDelete(" + eventIndex + ")\"/>";

            dynamicTable = dynamicTable + tblCellPrefixSearch + editBtn + " " + deleteBtn + tblCellSuffix;
        }

        if (curResult != null && curResult != '')
            dynamicTable = dynamicTable + tblCellPrefixLeftAlignSearch + curResult + tblCellSuffix;

        if (addButtons == 'false' && (curResult == null || curResult == ''))
            dynamicTable = dynamicTable + tblCellPrefixLeftAlignSearch + curResult + tblCellSuffix;
    }

    dynamicTable = dynamicTable + '</tr>';

    return dynamicTable;
}
function DisplaySearchCriteria(show) {
    var srchReqButton = $("#SearchButtonDisplay");
    var srchDisplay = $("#SearchDisplay");
    var srchCriteria = $("#SearchCriteriaDisplay");

    if (show == 'true') {
        srchCriteria.show();
        srchDisplay.show();
    }
    else {
        srchDisplay.hide();
        srchCriteria.hide();
   }
}

//bucket list  ---------------------------------------
function DisplayBucketList(data) {
    var list = BuildBucketList(data);
    var listDisplay = $("#BucketListDisplay");

    listDisplay.removeClass("BucketDisplayCenter");
    listDisplay.addClass("BucketDisplayCenter");
    listDisplay.html('');
    listDisplay.append('<p>My Bucket List</p>');
    listDisplay.append(list);
    listDisplay.show();

    $("#Html5JqueryHeader").hide();
    $("#Html5JqueryFooter").show();
    $("#Html5JqueryBody").css('background-color', '#CBE9EF;');
    $("#MenuRequestDisplay").css('background-color', '#CBE9EF;');
    $("#Content").css('background-color', 'white');
    $("#ParentBody").css('background-color', '#CBE9EF;');
}
function BuildBucketList(data) {
    var bucketList = '';
    var tblPrefix = '<table width="100%"><tbody>';
    var tblRowPrefix = '<tr>';
    var addButtons = 0;
    var tblRowSuffix = '</tr>';
    var tblSuffix = '</tbody></table>';

    bucketList = tblPrefix;
    var outerCount = data.length;
    if (data == null || data[0] == null || data[0]== "No Items")
        outerCount = 0;
    for (var outerCtr = 0; outerCtr < outerCount; outerCtr++) {
        var row = data[outerCtr];

        if (row == null || row == "")
            continue;

        row = row.split(",");

        if (outerCtr > 0)
            addButtons = 1;

        bucketList = bucketList +tblRowPrefix;

        bucketList = AddRow(bucketList, row, addButtons, outerCtr);

        bucketList = bucketList +tblRowSuffix;
        }

    bucketList = bucketList +tblSuffix;

    return bucketList;
}
function AddRow(bucketList, row, addButtons, index) {
    var ratingBtn;

    var curRanking = row[3];
    if (curRanking == RANKING_OPTIONS.HOT)
        ratingBtn = "<input type=\"button\" class=\"BLButtonHot\" />";
    else if (curRanking == RANKING_OPTIONS.WARM)
        ratingBtn = "<input type=\"button\" class=\"BLButtonWarm\" />";
    else
        ratingBtn = "<input type=\"button\" class=\"BLButtonCold\" />";

    var innerCount = row.length;
    for (var innerCtr = 0; innerCtr < innerCount; innerCtr++) {
        if (row[innerCtr] != '') {
            if (innerCtr == 1) {
                bucketList = bucketList + tblCellPrefixLeftAlign
                    + (index + 1) + " - " + row[innerCtr] + tblCellSuffix;
            }
        }
    }
    
    var editBtn = "<input type=\"button\" id=\"btnEdit" + index + "\" name=\"btnEdit" + index + "\" class=\"BLButtonEdit\" onclick=\"ProcessEdit(" + row[7] + ")\"/>";
    var deleteBtn = "<input type=\"button\" id=\"btnDelete" + index + "\" name=\"btnDelete" + index + "\" class=\"BLButtonDelete\" onclick=\"ProcessDelete(" + row[7] + ")\"/>";

    bucketList = bucketList + tblCellPrefixCenter + ratingBtn + tblCellSuffix;
    bucketList = bucketList + tblCellPrefix + editBtn + " " + deleteBtn + tblCellSuffix;

    return bucketList;
}

//Sort --------------------------------------------------
function DisplaySortedBucketList(data) {
    data = data.split(';');
    var list = BuildBucketList(data);

    var listDisplay = $("#BucketListDisplay");

    listDisplay.removeClass("BucketDisplayCenter");
    listDisplay.addClass("BucketDisplayCenter");
    listDisplay.html('');
    listDisplay.append('<p>My Bucket List</p>');
    listDisplay.append(list);
    listDisplay.show();

    $("#Html5JqueryHeader").hide();
    $("#Html5JqueryFooter").show();
    $("#Html5JqueryBody").css('background-color', '#CBE9EF;');
    $("#MenuRequestDisplay").css('background-color', '#CBE9EF;');
    $("#Content").css('background-color', 'white');
    $("#ParentBody").css('background-color', '#CBE9EF;');
}



