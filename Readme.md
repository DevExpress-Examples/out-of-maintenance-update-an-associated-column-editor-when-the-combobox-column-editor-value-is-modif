<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/Controllers/HomeController.vb))
* [Category.cs](./CS/Models/Category.cs) (VB: [Category.vb](./VB/Models/Category.vb))
* [NorthwindDataProvider.cs](./CS/Models/NorthwindDataProvider.cs) (VB: [NorthwindDataProvider.vb](./VB/Models/NorthwindDataProvider.vb))
* [Product.cs](./CS/Models/Product.cs) (VB: [Product.vb](./VB/Models/Product.vb))
* [GridViewPartial.cshtml](./CS/Views/Home/GridViewPartial.cshtml)
* [HiddenColumn.cshtml](./CS/Views/Home/HiddenColumn.cshtml)
* [Index.cshtml](./CS/Views/Home/Index.cshtml)
* [ServerSideCalculation.cshtml](./CS/Views/Home/ServerSideCalculation.cshtml)
* **[SimplestApproach.cshtml](./CS/Views/Home/SimplestApproach.cshtml)**
<!-- default file list end -->
# Update an associated column editor when the ComboBox column editor value is modified
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/t360468/)**
<!-- run online end -->


This as an MVC version of the <a href="https://www.devexpress.com/Support/Center/p/T359598">T359598 - ASPxGridView - How to update an associated column editor in the Edit Form when the GridViewDataComboBoxColumn editor value is modified</a> code example. A custom callback to the server is handled via the <strong>jQuery.ajax</strong> function (e.g., see <a href="https://www.devexpress.com/Support/Center/p/E4063">E4063 - How to use the jQuery.ajax function with DevExpress MVC Extensions</a>)<br><br>Note that we have used the techniques from the following webpages in this example:<br><br><a href="https://documentation.devexpress.com/#AspNet/CustomDocument9941">Passing Values to a Controller Action through Callbacks</a> <br><a href="https://www.devexpress.com/Support/Center/p/T191698">T191698 - How to isolate extension settings into separate helper class and share a single partial view to display multiple extensions</a> <br><br>Actual updating of the underlying datasource is not implemented in this example. Please review the <a href="https://www.devexpress.com/Support/Center/p/E3983">E3983 - GridView - How to edit in memory data source</a> code example if you are interested in this scenario.

<br/>


