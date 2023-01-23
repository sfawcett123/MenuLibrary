# Menu Library

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=sfawcett123_MenuLibrary&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=sfawcett123_MenuLibrary)
[![codecov](https://codecov.io/gh/sfawcett123/MenuLibrary/branch/master/graph/badge.svg?token=XOKNKO7RMM)](https://codecov.io/gh/sfawcett123/MenuLibrary)

A simple ASP.NET / NPM library pair to automate the production of the left hand menu. 

This has probably been done elsewhere and more than likely better, but you don't learn unless you try.

## Packages
There are two packages included in this project:
- [NuGet Package](https://www.nuget.org/packages/MenuLibrary/)
- [npm Package](https://www.npmjs.com/package/@sfawcett191/menulibrary)

### Cookies
This impemtation uses a cookie to track whether the menu is open or closed.

## To Use
You need to configure which controller methods will be displayed in the menu, and then call the menu in the HTML.

### Decorations
The valid list of decorations are:

-   Display - Display the method as a menu item, default = True 
-   Order - Order of item on menu Display
-   Name  - Display name
-   Icon  - Icon, default = fas-circle 
-   Route - Route, default = Home
-   ClassNavItem  - Class of Nav Item
-   ClassNavLink  - Class on Nav Link
-   IconGroup  - Icon group, default = fas
-   Parent - Parent nav item, default = None
 
### Use in Controllers
Simply add decoarations to your Control. The minimum decoration you needs is the Name

```C
        [MenuLibrary.MenuAttributes(Name = "Documentation", Icon = "fa-book" , Order = 50 )]
        public IActionResult Docs()
        {
            return Redirect("https://sfawcett123.github.io/FlightSimulator/");
        }
```

### Use in HTML
To include in your layouts page, you simply need to call the LeftMenu Method

```html
@using MenuLibrary
<script src="~/lib/menulibrary/dist/js/menu.js"></script>
<link href="~/lib/menulibrary/dist/css/menu.css" rel="stylesheet" />

<body id=@Menu.BODY_ID>
    <header class="header" id="header">
        <div class="navbar_left header_toggle">
            <a class="navbar_brand">Demo</a>
        </div>
    </header>

    @Html.Raw( LeftMenu.Display( Menu.GetSubClasses<Controller>()) )

    <!--Container Main start-->
    <div class="content">
        Something interesting
    <!--Container Main end-->
    </div
```
