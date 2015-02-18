# FluentBootstrap

## Overview

FluentBootstrap provides extensions, helper classes, model binding, and other goodies to help you use the Bootstrap CSS framework from .NET code. It enables using Bootstrap (and to some extent, regular HTML elements) in a variety of different ways without having to worry about HTML, CSS, etc. The goal is to have strongly-typed classes, methods, and extensions that cover as much of the Bootstrap library as possible. Support for generating HTML strings without a web framework, ASP.NET WebPages, ASP.NET MVC, and T4MVC is currently provided.

## Status

![BuildAppVeyor](https://img.shields.io/appveyor/ci/DaveGlick/fluentbootstrap-341.svg?style=flat-square&label=AppVeyor%20Build)

[![FluentBootstrapNuGet](https://img.shields.io/nuget/v/FluentBootstrap.svg?style=flat-square&label=FluentBootstrap)](http://www.nuget.org/packages/FluentBootstrap/)

[![FluentBootstrapWebPagesNuGet](https://img.shields.io/nuget/v/FluentBootstrap.WebPages.svg?style=flat-square&label=FluentBootstrap.WebPages)](http://www.nuget.org/packages/FluentBootstrap.WebPages/) 

[![FluentBootstrapMvcNuGet](https://img.shields.io/nuget/v/FluentBootstrap.Mvc.svg?style=flat-square&label=FluentBootstrap.Mvc)](http://www.nuget.org/packages/FluentBootstrap.Mvc/) 

[![FluentBootstrapMvcT4MVCNuGet](https://img.shields.io/nuget/v/FluentBootstrap.Mvc.T4MVC.svg?style=flat-square&label=FluentBootstrap.Mvc.T4MVC)](http://www.nuget.org/packages/FluentBootstrap.Mvc.T4MVC/) 

## Example

FluentBootstrap lets you output this:

```
<nav class="navbar-static-top navbar-default navbar" 
 id="navbar" role="navigation">
 <div class="container-fluid">
  <div class="navbar-header">
   <a class="navbar-brand" href="#">FluentBootstrap</a>
   <button class="collapsed navbar-toggle" data-target="#navbar-collapse"
    data-toggle="collapse" type="button">
    <span class="sr-only">Toggle Navigation</span>
    <span class="icon-bar"></span>
    <span class="icon-bar"></span>
    <span class="icon-bar"></span>
   </button>
  </div>
  <div class="collapse navbar-collapse" id="navbar-collapse">
   <div class="navbar-left navbar-nav nav">
    <li><a href="/">Introduction</a></li>
    <li><a href="/Installation">Installation</a></li>
    <li><a href="/Usage">Usage</a></li>
    <li><a href="/Development">Development</a></li>
   </div>
  </div>
 </div>
</nav>
```

By writing this (for example, if using from an ASP.NET MVC view):

```
@using (var navbar = Html.Bootstrap().Navbar("FluentBootstrap")
    .SetPosition(NavbarPosition.StaticTop).Begin())
{
    @navbar.NavbarLink("Introduction", "/")
    @navbar.NavbarLink("Installation", "/Installation")
    @navbar.NavbarLink("Usage", "/Usage")
    @navbar.NavbarLink("Development", "/Development")
}
```

## More Information
Please see the project site at http://www.fluentbootstrap.com for more information, installation instructions, and code examples.
