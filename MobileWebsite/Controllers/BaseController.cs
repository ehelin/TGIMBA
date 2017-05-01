using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileApplication.Shared;

using MobileWebsite.Controllers;
using DataProvider.Interfaces;
using DataProvider;
using Shared.Dto;

namespace MobileApplication.Controllers
{
    public class BaseController : Controller
    {
        protected void SetMobileFlag()
        {
            if (HttpContext != null
                    && HttpContext.Request != null
                        && HttpContext.Request.Browser != null)
            {
                Session[SessionConstants.IS_MOBILE] = HttpContext.Request.Browser.IsMobileDevice;
            }
            else
                throw new Exception(Error.ERR_000001 + "-" + ErrorMsg.ERR_MSG_000001); 
        }
        protected bool IsMobile()
        {
            if (Session[SessionConstants.IS_MOBILE] != null)
                return Convert.ToBoolean(Session[SessionConstants.IS_MOBILE]);
            else
                return false;
        }
        protected BrowserData GetBrowserData()
        {
            BrowserData bd = new BrowserData();

            System.Web.HttpBrowserCapabilitiesBase browser = HttpContext.Request.Browser;

            bd.ActiveXControls = browser.ActiveXControls;
            bd.AOL = browser.AOL;
            bd.BackgroundSounds = browser.BackgroundSounds;
            bd.Beta = browser.Beta;
            bd.Browser = browser.Browser;
            bd.Browsers = browser.Browsers;
            bd.CanCombineFormsInDeck = browser.CanCombineFormsInDeck;
            bd.CanInitiateVoiceCall = browser.CanInitiateVoiceCall;
            bd.CanRenderAfterInputOrSelectElement = browser.CanRenderAfterInputOrSelectElement;
            bd.CanRenderEmptySelects = browser.CanRenderEmptySelects;
            bd.CanRenderInputAndSelectElementsTogether = browser.CanRenderInputAndSelectElementsTogether;
            bd.CanRenderMixedSelects = browser.CanRenderMixedSelects;
            bd.CanRenderOneventAndPrevElementsTogether = browser.CanRenderOneventAndPrevElementsTogether;
            bd.CanRenderPostBackCards = browser.CanRenderPostBackCards;
            bd.CanRenderSetvarZeroWithMultiSelectionList = browser.CanRenderSetvarZeroWithMultiSelectionList;
            bd.CanSendMail = browser.CanSendMail;
            bd.Capabilities = browser.Capabilities;
            bd.CDF = browser.CDF;
            bd.ClrVersion = browser.ClrVersion.ToString();
            bd.Cookies = browser.Cookies;
            bd.Crawler = browser.Crawler;
            bd.DefaultSubmitButtonLimit = browser.DefaultSubmitButtonLimit;
            bd.EcmaScriptVersion = browser.EcmaScriptVersion.ToString();
            bd.Frames = browser.Frames;
            bd.GatewayMajorVersion = browser.GatewayMajorVersion;
            bd.GatewayMinorVersion = browser.GatewayMinorVersion;
            bd.GatewayVersion = browser.GatewayVersion;
            bd.HasBackButton = browser.HasBackButton;
            bd.HidesRightAlignedMultiselectScrollbars = browser.HidesRightAlignedMultiselectScrollbars;
            bd.HtmlTextWriter = browser.HtmlTextWriter;
            bd.Id = browser.Id;
            bd.InputType = browser.InputType;
            bd.IsColor = browser.IsColor;
            bd.IsMobileDevice = browser.IsMobileDevice;
            bd.JavaApplets = browser.JavaApplets;
            bd.JScriptVersion = browser.JScriptVersion.ToString();
            bd.MajorVersion = browser.MajorVersion;
            bd.MaximumHrefLength = browser.MaximumHrefLength;
            bd.MaximumRenderedPageSize = browser.MaximumRenderedPageSize;
            bd.MaximumSoftkeyLabelLength = browser.MaximumSoftkeyLabelLength;
            bd.MinorVersion = browser.MinorVersion;
            bd.MinorVersionString = browser.MinorVersionString;
            bd.MobileDeviceManufacturer = browser.MobileDeviceManufacturer;
            bd.MobileDeviceModel = browser.MobileDeviceModel;
            bd.MSDomVersion = browser.MSDomVersion.ToString();
            bd.NumberOfSoftkeys = browser.NumberOfSoftkeys;
            bd.Platform = browser.Platform;
            bd.PreferredImageMime = browser.PreferredImageMime;
            bd.PreferredRenderingMime = browser.PreferredRenderingMime;
            bd.PreferredRenderingType = browser.PreferredRenderingType;
            bd.PreferredRequestEncoding = browser.PreferredRequestEncoding;
            bd.PreferredResponseEncoding = browser.PreferredResponseEncoding;
            bd.RendersBreakBeforeWmlSelectAndInput = browser.RendersBreakBeforeWmlSelectAndInput;
            bd.RendersBreaksAfterHtmlLists = browser.RendersBreaksAfterHtmlLists;
            bd.RendersBreaksAfterWmlAnchor = browser.RendersBreaksAfterWmlAnchor;
            bd.RendersBreaksAfterWmlInput = browser.RendersBreaksAfterWmlInput;
            bd.RendersWmlDoAcceptsInline = browser.RendersWmlDoAcceptsInline;
            bd.RendersWmlSelectsAsMenuCards = browser.RendersWmlSelectsAsMenuCards;
            bd.RequiredMetaTagNameValue = browser.RequiredMetaTagNameValue;
            bd.RequiresAttributeColonSubstitution = browser.RequiresAttributeColonSubstitution;
            bd.RequiresContentTypeMetaTag = browser.RequiresContentTypeMetaTag;
            bd.RequiresControlStateInSession = browser.RequiresControlStateInSession;
            bd.RequiresDBCSCharacter = browser.RequiresDBCSCharacter;
            bd.RequiresHtmlAdaptiveErrorReporting = browser.RequiresHtmlAdaptiveErrorReporting;
            bd.RequiresLeadingPageBreak = browser.RequiresLeadingPageBreak;
            bd.RequiresNoBreakInFormatting = browser.RequiresNoBreakInFormatting;
            bd.RequiresOutputOptimization = browser.RequiresOutputOptimization;
            bd.RequiresPhoneNumbersAsPlainText = browser.RequiresPhoneNumbersAsPlainText;
            bd.RequiresSpecialViewStateEncoding = browser.RequiresSpecialViewStateEncoding;
            bd.RequiresUniqueFilePathSuffix = browser.RequiresUniqueFilePathSuffix;
            bd.RequiresUniqueHtmlCheckboxNames = browser.RequiresUniqueHtmlCheckboxNames;
            bd.RequiresUniqueHtmlInputNames = browser.RequiresUniqueHtmlInputNames;
            bd.RequiresUrlEncodedPostfieldValues = browser.RequiresUrlEncodedPostfieldValues;
            bd.ScreenBitDepth = browser.ScreenBitDepth;
            bd.ScreenCharactersHeight = browser.ScreenCharactersHeight;
            bd.ScreenCharactersWidth = browser.ScreenCharactersWidth;
            bd.ScreenPixelsHeight = browser.ScreenPixelsHeight;
            bd.ScreenPixelsWidth = browser.ScreenPixelsWidth;
            bd.SupportsAccesskeyAttribute = browser.SupportsAccesskeyAttribute;
            bd.SupportsBodyColor = browser.SupportsBodyColor;
            bd.SupportsBold = browser.SupportsBold;
            bd.SupportsCacheControlMetaTag = browser.SupportsCacheControlMetaTag;
            bd.SupportsCallback = browser.SupportsCallback;
            bd.SupportsCss = browser.SupportsCss;
            bd.SupportsDivAlign = browser.SupportsDivAlign;
            bd.SupportsDivNoWrap = browser.SupportsDivNoWrap;
            bd.SupportsEmptyStringInCookieValue = browser.SupportsEmptyStringInCookieValue;
            bd.SupportsFontColor = browser.SupportsFontColor;
            bd.SupportsFontName = browser.SupportsFontName;
            bd.SupportsFontSize = browser.SupportsFontSize;
            bd.SupportsImageSubmit = browser.SupportsImageSubmit;
            bd.SupportsIModeSymbols = browser.SupportsIModeSymbols;
            bd.SupportsInputIStyle = browser.SupportsInputIStyle;
            bd.SupportsInputMode = browser.SupportsInputMode;
            bd.SupportsItalic = browser.SupportsItalic;
            bd.SupportsJPhoneMultiMediaAttributes = browser.SupportsJPhoneMultiMediaAttributes;
            bd.SupportsJPhoneSymbols = browser.SupportsJPhoneSymbols;
            bd.SupportsQueryStringInFormAction = browser.SupportsQueryStringInFormAction;
            bd.SupportsRedirectWithCookie = browser.SupportsRedirectWithCookie;
            bd.SupportsSelectMultiple = browser.SupportsSelectMultiple;
            bd.SupportsUncheck = browser.SupportsUncheck;
            bd.SupportsXmlHttp = browser.SupportsXmlHttp;
            bd.Tables = browser.Tables;
            bd.Type = browser.Type;
            bd.UseOptimizedCacheKey = browser.UseOptimizedCacheKey;
            bd.VBScript = browser.VBScript;
            bd.Version = browser.Version;
            bd.W3CDomVersion = browser.W3CDomVersion.ToString();
            bd.Win16 = browser.Win16;
            bd.Win32 = browser.Win32;

            return bd;
        }
    }
}
