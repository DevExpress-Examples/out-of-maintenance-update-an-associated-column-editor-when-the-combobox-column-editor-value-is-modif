using System.Web.Mvc;

namespace GridUpdateComboMvc {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult SimplestApproach() {
            return View();
        }

        public ActionResult ServerSideCalculation() {
            return View();
        }

        public ActionResult HiddenColumn() {
            return View();
        }

        public ActionResult GridViewPartial(bool? hiddenColumnScenario) {
            ViewData["hiddenColumnScenario"] = hiddenColumnScenario;
            return PartialView();
        }

        public ActionResult GridViewUpdatePartial(Product product) {
            // Update logic is not implemented in this example
            return PartialView("GridViewPartial");
        }

        public ActionResult ServerSideCalculationCallbackActionMethod(int categoryID) {
            decimal someConstant = 10m;
            string result = (categoryID * someConstant).ToString();

            return Content(result);
        }

        public ActionResult HiddenColumnCallbackActionMethod(int categoryID) {
            string someConstant = " Test";
            string description = NorthwindDataProvider.GetCategoryDescriptionById(categoryID);

            return Content(description + someConstant);
        }
    }
}