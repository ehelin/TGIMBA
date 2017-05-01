//display variables ---------------------------------------
var tblCellPrefix = '<td>';
var tblCellPrefixLeftAlign = '<td class="DesktopTableCell">';
var tblCellSuffix = '</td>';

//Login ---------------------------------------------------
function DisplayDesktopRegistration() {
    var loginCntrl = $("#LoginDisplay");

    SetPageForLogin();
    loginCntrl.html('');

    var registerDisplay = REGISTRATION_FORM;

    loginCntrl.append(registerDisplay);
    loginCntrl.show();
}
function DisplayDesktopLogin() {
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
    $("#BucketListDisplay").html('');
    $("#MenuDisplay").show();
    $("#OptionsDisplay").hide();
    $("#AddItemDesktopDisplay").hide();
    $("#SearchResultsMobileDisplay").hide();
    $("#SortBucketListOptions").hide();
    $("#Html5JqueryBody").hide();
    $("#MenuRequestDisplay").hide();
    $("#HeaderLabel").hide();
    $("#Html5JqueryContentDiv").hide();
    $("#Html5JqueryFooter").hide();
    $("#Html5JqueryArticleContent").hide();
    $("#DesktopCategoryFilter").hide();
    $("#LoginDisplay").hide();
    $("#MenuDisplay").hide();
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
    $("#DesktopTest").hide();
    $("#SearchTerm").val('');
    $("#SortBucketListOptions").html('');
    $("#SortBucketListOptions").hide();
    $("#BIItemName").val('');
    $("#BLIDateTime").val('');
    $("#BIRanking").val('');
    $("#BIAchieved").val('');
}

//Cursor --------------------------------------------------
function LinkCursor(link) {
    var name = link.id;
    var link = $("#" + name);
    link.css('background-color', '#cbe9dd');
    link.css('cursor', 'pointer');
}
function NormalCursor(link) {
    var name = link.id;
    var link = $("#" + name);
    link.css('background-color', '#cbe9ef');
    link.css('cursor', 'auto');
}

//Category --------------------------------------------------
function BuildCategoryFilter() {
    var filterContainer = $("#DesktopCategoryFilter");
    var categoryFilter = SetCategoryFilterDisplay();

    filterContainer.html('');
    filterContainer.append(categoryFilter);
}
function GetCategoryButton(rowCategory) {
    var ratingBtn = '';

    if (rowCategory == 'Hot')
        ratingBtn = "<input type=\"button\" class=\"BLButtonHot\" />";
    else if (rowCategory == 'Warm')
        ratingBtn = "<input type=\"button\" class=\"BLButtonWarm\" />";
    else
        ratingBtn = "<input type=\"button\" class=\"BLButtonCold\" />";

    return ratingBtn;
}
function SetCategoryFilterDisplay() {
    var categoryFilter = '';
    var prefix = '<div class="importanceCategoryFilter">'
    var suffix = '</div> ';

    categoryFilter = prefix;

    categoryFilter = categoryFilter + "<input type=\"button\" id=\"DesktopHotFilterButton\" name=\"DesktopHotFilterButton\" class=\"BLButtonHotFilter\"  onclick=\"ProcessCategoryFilterEdit(" + 1 + ")\"/>";
    categoryFilter = categoryFilter + "<input type=\"button\" id=\"DesktopWarmFilterButton\" name=\"DesktopWarmFilterButton\" class=\"BLButtonWarmFilter\" onclick=\"ProcessCategoryFilterEdit(" + 2 + ")\"/>";
    categoryFilter = categoryFilter + "<input type=\"button\" id=\"DesktopColdFilterButton\" name=\"DesktopColdFilterButton\" class=\"BLButtonColdFilter\" onclick=\"ProcessCategoryFilterEdit(" + 3 + ")\"/>";
    categoryFilter = categoryFilter + "<input type=\"button\" id=\"DesktopClearFilterButton\" name=\"DesktopClearFilterButton\" class=\"BLButtonClearFilter\" onclick=\"ProcessCategoryFilterEdit(" + 0 + ")\"/>";

    categoryFilter = categoryFilter + suffix;

    return categoryFilter;
}

//Page navigation ------------------------------------
function DisplayPage(PageToDisplay) {
    ResetPageDivs();

    if (PageToDisplay != null) {
        $("#MenuRequestDisplay").hide();

        if (PageToDisplay == "MenuDisplay") {
            $("#Html5JqueryBody").hide();
            $("#MenuDisplay").show();
        }

        else if (PageToDisplay == "OptionsDisplay") {
            $("#Html5JqueryBody").hide();
            $("#MenuDisplay").hide();
            $("#OptionsDisplay").show();
        }

        else if (PageToDisplay == "AddItemDisplay") {
            $("#Html5JqueryBody").hide();
            $("#MenuDisplay").hide();
            $("#AddItemDisplay").show();

            $("#CancelAddItemDisplay").click(GlobalCancelEventClick);
        }

        else if (PageToDisplay == "SearchItemDisplay") {
            $("#Html5JqueryBody").hide();
            $("#MenuDisplay").hide();
            $("#SearchResultsDisplay").hide();
            $("#SearchItemDisplay").show();
        }

        else if (PageToDisplay == "SearchResultsMobileDisplay") {
            $("#Html5JqueryBody").hide();
            $("#MenuDisplay").hide();
            $("#SearchItemDisplay").hide();
            $("#DesktopTest").hide();
            $("#SearchResultsMobileDisplay").show();
            $("#CancelSearchResultDisplay").click(GlobalCancelEventClick);
        }

        else if (PageToDisplay == "EditBIItem") {
            $("#Html5JqueryBody").hide();
            $("#MenuDisplay").hide();
            $("#AddItemDisplay").show();
            $("#BucketListItemDisplay").show();
            $("#BucketListItemDisplayTable").show();
            $("#EditBIButtons").show();
            $("#SearchResultsMobileDisplay").hide();
            $("#CancelEditItemDisplay").click(GlobalCancelEventClick);
        }

        else if (PageToDisplay == "EditBIItemDesktop") {
            $("#Html5JqueryBody").hide();
            $("#DesktopTest").show();
            $("#AddItemDesktopDisplay").show();
            $("#BucketListItemDesktopDisplay").show();

            $("#CancelDesktopEditDisplay").click(GlobalCancelEventClick);
        }

        else if (PageToDisplay == "SortBucketListOptions") {
            $("#SortBucketListOptions").html('');
            $("#SortBucketListOptions").append(GetSortOptions());
            $("#SortBucketListOptions").show();
            $("#Html5JqueryBody").hide();
        }

        $("#PageDisplay").show();
    }
    else
        $("#PageDisplay").show();
}
function ResetPageDivs()
{
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
    $("#BucketListItemDesktopDisplay").show();
    $("#DesktopTest").hide();
    $("#SearchTerm").val('');
    $("#SortBucketListOptions").html('');
    $("#SortBucketListOptions").hide();
    $("#LoginDisplay").html('');
    $("#LoginDisplay").hide();
    $("#Html5JqueryArticleContent").show();
    $("#MenuSpan").show();
    $("#Html5JqueryContentDiv").show();
    $("#HeaderLabel").show();
    $("#DesktopCategoryFilter").show();
}
function ClearBIItemForm() {
    $("#BIItemName").val('');
    $("#BLIDateTime").val('');
    $("#BIRanking").val('');
    $("#BIAchieved").val('');
}

//Add Item -------------------------------------------
function DisplayAddBIForm() {
    ClearBIItemForm();
    DisplayAddDesktopBIForm();
    var addBIDisplay = $("#BucketListItemDisplay");

    $("#BLIDateTime").val(GetDateTime());
    $("#RankingCategoryInput").html('');
    $("#RankingCategoryInput").append(GetRankingOptionsAsSelectHtml(null));
    $("#AchievedInput").html('');
    $("#AchievedInput").append(GetItemAchievedAsCheckboxHtml(null));

    addBIDisplay.show();

    $("#MasterEditDeskop").hide();
    $("#AddItemDisplay").show();
    $("#BucketListItemDisplay").show();
    $("#BucketListItemDisplayTable").show();
    $("#EditRowTR").html('');
    $("#AddBIButtons").show();
}
function DisplayAddDesktopBIForm() {
    var bucketList = '';
    var divMasterEditPrefix = '<div id=\"MasterEditDeskop\" name=\"MasterEditDesktop\">';
    var divMasterEditSuffix = '</div>';
    var tblPrefix = '<table class="DeskTopBucketListTable"><tbody>';
    var tblRowPrefix = '<tr>';
    var tblCellPrefix = '<td>';
    var addButtons = 0
    var tblRowSuffix = '</tr>';
    var tblCellSuffix = '</td>';
    var tblSuffix = '</tbody></table>';

    ClearBIItemForm();
    var bucketEditDisplay = '';
    var addBIDisplay = $("#BucketListItemDesktopDisplay");
    addBIDisplay.html('');

    bucketEditDisplay = bucketEditDisplay + ADD_ITEM_FORM;

    bucketEditDisplay = bucketEditDisplay + divMasterEditPrefix + tblPrefix;
    bucketEditDisplay = bucketEditDisplay + tblRowPrefix + tblCellPrefix + "Name: " + '' + tblCellSuffix;  //Name
    bucketEditDisplay = bucketEditDisplay + tblCellPrefix + "Date: " + '' + tblCellSuffix;  //Date
    bucketEditDisplay = bucketEditDisplay + tblCellPrefix + "Ranking: " + '' + tblCellSuffix;  //Ranking
    bucketEditDisplay = bucketEditDisplay + tblCellPrefix + "Achieved: " + '' + tblCellSuffix + tblRowSuffix;  //Achieved

    bucketEditDisplay = bucketEditDisplay + tblSuffix + divMasterEditSuffix;
    bucketEditDisplay = bucketEditDisplay + '<input type=\"button\" class=\"BLButtonMenu\" value=\"Cancel\" id="CancelDesktopEditDisplay" name="CancelDesktopEditDisplay"/>';

    addBIDisplay.append(bucketEditDisplay);

    $("#AddBIButtonSubmit").click(AddBIButtonSubmitClick);

    DisplayPage("EditBIItemDesktop");
}

//edit -----------------------------------------------
function DisplayEditDesktopBIForm(item, index, addHeaderButtons) {
    var bucketList = '';
    var divMasterEditPrefix = '<div id=\"MasterEditDeskop\" name=\"MasterEditDesktop\">';
    var divMasterEditSuffix = '</div>';
    var tblPrefix = '<table class="DeskTopBucketListTable"><tbody>';
    var tblRowPrefix = '<tr>';
    var tblCellPrefix = '<td>';
    var addButtons = 0
    var tblRowSuffix = '</tr>';
    var tblCellSuffix = '</td>';
    var tblSuffix = '</tbody></table>';

    ClearBIItemForm();
    var bucketEditDisplay = '';
    var addBIDisplay = $("#BucketListItemDesktopDisplay");
    addBIDisplay.html('');

    var data = item.split(',');

    if (addHeaderButtons != null) {
        bucketEditDisplay = '<input type=\"button\" class=\"BLButtonMenu\" id=\"DesktopAddButton\" name=\"DesktopAddButton\" value=\"Add\" onclick=\"AddBucketListItemClick()\"/>&nbsp;';
        bucketEditDisplay = bucketEditDisplay + '<input type=\"button\" class=\"BLButtonMenu\" id=\"DesktopEditButton\" name=\"DesktopEditButton\" value=\"Edit\" onclick=\"ProcessEditDetail(' + index + ')\"/>&nbsp;';
        bucketEditDisplay = bucketEditDisplay + '<input type=\"button\" class=\"BLButtonMenu\" id=\"DesktopDeleteButton\" name=\"DesktopDeleteButton\" value=\"Delete\" onclick=\"ProcessDelete(' + index + ')\"/>';
    }

    bucketEditDisplay = bucketEditDisplay + ADD_ITEM_FORM;

    bucketEditDisplay = bucketEditDisplay + divMasterEditPrefix + tblPrefix;
    bucketEditDisplay = bucketEditDisplay + tblRowPrefix + tblCellPrefix + "Name: " + data[1] + tblCellSuffix + tblRowSuffix;  //Name
    bucketEditDisplay = bucketEditDisplay + tblRowPrefix + tblCellPrefix + "" + tblCellSuffix + tblRowSuffix;                  //empty row 
    bucketEditDisplay = bucketEditDisplay + tblCellPrefix + "Date: " + data[2] + tblCellSuffix + tblRowSuffix;                 //Date
    bucketEditDisplay = bucketEditDisplay + tblRowPrefix + tblCellPrefix + "" + tblCellSuffix + tblRowSuffix;                  //empty row 
    bucketEditDisplay = bucketEditDisplay + tblCellPrefix + "Ranking: " + data[3] + tblCellSuffix + tblRowSuffix;              //Ranking
    bucketEditDisplay = bucketEditDisplay + tblRowPrefix + tblCellPrefix + "" + tblCellSuffix + tblRowSuffix;                  //empty row 
    bucketEditDisplay = bucketEditDisplay + tblCellPrefix + "Achieved: " + data[4] + tblCellSuffix + tblRowSuffix;             //Achieved

    bucketEditDisplay = bucketEditDisplay + tblSuffix + divMasterEditSuffix;
    bucketEditDisplay = bucketEditDisplay + '<input type=\"button\" class=\"BLButtonMenu\" value=\"Cancel\" id="CancelDesktopEditDisplay" name="CancelDesktopEditDisplay"/>';

    addBIDisplay.append(bucketEditDisplay);

    DisplayPage("EditBIItemDesktop");
}
function DisplayEditBIForm(item) {
    ClearBIItemForm();
    DisplayEditDesktopBIForm(item, 0, null);
    var addBIDisplay = $("#BucketListItemDisplay");
    var data = item.split(',');

    //TODO - figure out good way to trim leading/trailing commas, use here and revert back to 0,1,2 etc.
    $("#BIItemName").val(data[1]);
    $("#BLIDateTime").val(data[2]);
    $("#RankingCategoryInput").html('');
    $("#RankingCategoryInput").append(GetRankingOptionsAsSelectHtml(data[3]));
    $("#AchievedInput").html('');
    $("#AchievedInput").append(GetItemAchievedAsCheckboxHtml(data[4]));

    $("#MobileRecordId").val(data[5]); //TODO - make this dynamic so the record id is the last element

    $("#MasterEditDeskop").hide();
    $("#AddItemDisplay").show();
    $("#BucketListItemDisplay").show();
    $("#BucketListItemDisplayTable").show();
    $("#EditBIButtons").show();

    $("#EditBIButtonSubmit").click(EditBIButtonSubmitClick);
}

//Bucket list  ---------------------------------------
function DisplayBucketList(data) {
    var list = BuildBucketListDesktop(data);

    var listDisplay = $("#BucketListDisplay");

    listDisplay.removeClass("BucketDisplayCenter");
    listDisplay.addClass("BucketDisplayCenter");

    listDisplay.html('');
    listDisplay.append('<center><p>My Bucket List</p></center>');
    listDisplay.append(list);
    listDisplay.show();

    $("#Html5JqueryHeader").show();
    $("#Html5JqueryFooter").show();
}
function BuildBucketListDesktop(data) {
    var bucketList = '';
    var tblPrefix = '<table class="DeskTopBucketListTable"><tbody>';
    var tblRowPrefix = '<tr>';
    var addButtons = 0;

    BuildCategoryFilter();

    var tblRowSuffix = '</tr>';
    var tblSuffix = '</tbody></table>';

    bucketList = tblPrefix;
    var outerCount = data.length;
    for (var outerCtr = 0; outerCtr < outerCount; outerCtr++) {
        var row = data[outerCtr];

        if (row == null || row == "")
            continue;
        row = row.split(",");

        if (outerCtr > 0)
            addButtons = 1;

        bucketList = bucketList + tblRowPrefix;

        bucketList = AddRowDesktop(bucketList, row, addButtons, outerCtr);

        bucketList = bucketList + tblRowSuffix;
    }

    bucketList = bucketList + tblSuffix;

    return bucketList;
}
function AddRowDesktop(bucketList, row, addButtons, index) {
    var innerCount = row.length;
    var currentFilter = SessionGetCategoryFilter();
    var rowCategory = row[3];
    
    for (var innerCtr = 0; innerCtr < innerCount; innerCtr++) {
        if (row[innerCtr] != '') {
            if (innerCtr == 1) {

                //TODO - filter category code mess...refactor
                if (currentFilter == 0) {
                    bucketList = bucketList + "<td class=\"DesktopTableCell\" onmouseover=\"LinkCursor(this)\" onmouseout=\"NormalCursor(this)\" id=\"blLink" + index + "\" name=\"blLink" + index + "\">" +
                              "<a id=\"blAHrefLink" + index + "\" onClick=\"ProcessEdit(" + row[5] + "); return false;\"  >" + (index + 1) + " - "
                                  + row[innerCtr]

                    bucketList = bucketList + "<a/>" + "&nbsp;" + GetCategoryButton(rowCategory) + tblCellSuffix;
                }

                else if (currentFilter == 1 && rowCategory == 'Hot') {
                    bucketList = bucketList + "<td class=\"DesktopTableCell\" onmouseover=\"LinkCursor(this)\" onmouseout=\"NormalCursor(this)\" id=\"blLink" + index + "\" name=\"blLink" + index + "\">" +
                        "<a onClick=\"ProcessEdit(" + row[5] + "); return false;\"  >" + (index + 1) + " - " + row[innerCtr];

                    bucketList = bucketList + "<a/>" + "&nbsp;" + GetCategoryButton(rowCategory) + tblCellSuffix;
                }

                else if (currentFilter == 2 && rowCategory == 'Warm') {
                    bucketList = bucketList + "<td class=\"DesktopTableCell\" onmouseover=\"LinkCursor(this)\" onmouseout=\"NormalCursor(this)\" id=\"blLink" + index + "\" name=\"blLink" + index + "\">" +
                        "<a onClick=\"ProcessEdit(" + row[5] + "); return false;\"  >" + (index + 1) + " - " + row[innerCtr];

                    bucketList = bucketList + "<a/>" + "&nbsp;" + GetCategoryButton(rowCategory) + tblCellSuffix;
                }

                else if (currentFilter == 3 && rowCategory == 'Cool') {
                    bucketList = bucketList + "<td class=\"DesktopTableCell\" onmouseover=\"LinkCursor(this)\" onmouseout=\"NormalCursor(this)\" id=\"blLink" + index + "\" name=\"blLink" + index + "\">" +
                        "<a onClick=\"ProcessEdit(" + row[5] + "); return false;\"  >" + (index + 1) + " - " + row[innerCtr];

                    bucketList = bucketList + "<a/>" + "&nbsp;" + GetCategoryButton(rowCategory) + tblCellSuffix;
                }
            }
        }
    }

    return bucketList;
}

//search ------------------------------------------------------------------
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
    srchResultsDisplay.append(dynamicTable);

    DisplayPage("SearchResultsMobileDisplay");
}
function AddSearchRow(dynamicTable, results, addButtons, rowCounter) {
    dynamicTable = dynamicTable + '<tr>';
    var eventIndex = results[results.length - 1];
    var endIndexExit = 0;

    if (addButtons == 'true')
        endIndexExit = results.length - 1;
    else
        endIndexExit = results.length;

    var curResult = results[1];
    var listIndex = results[results.length - 1];

    curResult = curResult.replace(";", "");

    if (curResult != null && curResult != '')
        dynamicTable = dynamicTable
                    + "<td class=\"DesktopTableCellSearch\" onmouseover=\"LinkCursorSearch(this)\" onmouseout=\"NormalCursorSearch(this)\" id=\"blLink" + listIndex + "\" name=\"blLink" + listIndex + "\">" +
                                "<a id=\"ProcessEdit" + rowCounter + "\" name=\"ProcessEdit" + rowCounter + "\" onClick=\"ProcessEdit(" + listIndex + "); return false;\"  >"
                        +curResult
                        + "<a/>" + "&nbsp;"
                            + tblCellSuffix;

    if (addButtons == 'false' && (curResult == null || curResult == ''))
        dynamicTable = dynamicTable
        + "<td class=\"DesktopTableCellSearch\" onmouseover=\"LinkCursorSearch(this)\" onmouseout=\"NormalCursorSearch(this)\" id=\"blLink" + listIndex + "\" name=\"blLink" + listIndex + "\">" +
                    "<a id=\"ProcessEdit" + rowCounter + "\" name=\"ProcessEdit" + rowCounter + "\" onClick=\"ProcessEdit(" + listIndex + "); return false;\"  >"
                        +curResult
                        + "<a/>" + "&nbsp;"
                            + tblCellSuffix;

    dynamicTable = dynamicTable + '</tr>';

    return dynamicTable;
}
function LinkCursorSearch(link) {
    var name = link.id;
    var link = $("#" + name);
    link.css('background-color', '#cbe9ef');
    link.css('cursor', 'pointer');
}

function NormalCursorSearch(link) {
    var name = link.id;
    var link = $("#" + name);
    link.css('background-color', 'white');
    link.css('cursor', 'auto');
}

//Sort --------------------------------------------------
function DisplaySortedBucketList(data) {
    data = data.split(';');
    var list = BuildBucketListDesktop(data);

    var listDisplay = $("#BucketListDisplay");

    listDisplay.removeClass("BucketDisplayCenter");
    listDisplay.addClass("BucketDisplayCenter");

    listDisplay.html('');
    listDisplay.append('<center><p>My Bucket List</p></center>');
    listDisplay.append(list);
    listDisplay.show();

    $("#Html5JqueryHeader").show();
    $("#Html5JqueryFooter").show();
}
