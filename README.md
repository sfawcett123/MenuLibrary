# Menu Library

A simple ASP.NET library to automate the production of the left hand menu. 
This has probably been done elsewhere and more than likely better, but you don't learn unless you try.

### Cookies
This impemtation uses a cookie to track whether the menu is open or closed.


## To Use
You need to configure which controller methods will be displayed in the menu, and then call the menu in the HTML.

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
@Html.Raw( Menu.Css() )
@Html.Raw( Menu.Scripts() )

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

test
