Imports System.Web.Mvc

Namespace GridUpdateComboMvc
	Public Class HomeController
		Inherits Controller

		Public Function Index() As ActionResult
			Return View()
		End Function

		Public Function SimplestApproach() As ActionResult
			Return View()
		End Function

		Public Function ServerSideCalculation() As ActionResult
			Return View()
		End Function

		Public Function HiddenColumn() As ActionResult
			Return View()
		End Function

		Public Function GridViewPartial(ByVal hiddenColumnScenario? As Boolean) As ActionResult
			ViewData("hiddenColumnScenario") = hiddenColumnScenario
			Return PartialView()
		End Function

		Public Function GridViewUpdatePartial(ByVal product As Product) As ActionResult
			' Update logic is not implemented in this example
			Return PartialView("GridViewPartial")
		End Function

		Public Function ServerSideCalculationCallbackActionMethod(ByVal categoryID As Integer) As ActionResult
			Dim someConstant As Decimal = 10D
			Dim result As String = (categoryID * someConstant).ToString()

			Return Content(result)
		End Function

		Public Function HiddenColumnCallbackActionMethod(ByVal categoryID As Integer) As ActionResult
			Dim someConstant As String = " Test"
			Dim description As String = NorthwindDataProvider.GetCategoryDescriptionById(categoryID)

			Return Content(description & someConstant)
		End Function
	End Class
End Namespace