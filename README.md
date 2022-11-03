# Menu Library

## To include

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
