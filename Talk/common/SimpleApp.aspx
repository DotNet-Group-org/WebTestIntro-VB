<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="../MasterPage.master" %>
<asp:Content ContentPlaceHolderID="cph" runat="server">
    <p>
        Simple Localizied Web App</p>
    <p>
    Some notes:
    </p>
    <ul>
    <li>Summary
    <blockquote>The app is for a &quot;Birthday Club&quot; where users enter their name and next birthdate, and provides some feedback.</blockquote>
    </li>
    <li>
    Compatibility
    <blockquote>When I tried to use ASP.NET's built-in localization, I kept getting weird errors complaining about &quot;
    InitializeCulture&quot;, among other things.<br />
    I re-did the app as a Web Site, and the problems seemed to go away.<br />
    To use a web app with localization reliably, you will probably need to use your own provider, which gives you more 
    control anyway.
    </blockquote>
    </li>
    <li>Where's the code-behind logic?
    <blockquote>
    I tried to put as much code as possible into a &quot;Presenter&quot; class per the MVP pattern.  The particular 
    code in this example is based on the examples in June 2007's ASP.NET Pro, which you could have received for free
    if you attended the meeting last month.  Better yet, subscribe - it's a good magazine with consitently useful content.<br />
    <a href="http://www.aspnetpro.com/"><img src="../images/ASP_200707.gif" /></a>
    </blockquote>
    </li>
    </ul>
    <p>
    </p>

</asp:Content>
