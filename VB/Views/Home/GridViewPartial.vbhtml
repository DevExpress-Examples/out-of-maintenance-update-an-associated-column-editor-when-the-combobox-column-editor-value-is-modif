@Html.DevExpress().GridView( _
    Sub(settings)
            settings.Name = "GridView"
            settings.KeyFieldName = "ProductID"
            settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "GridViewPartial"}
            settings.SettingsEditing.UpdateRowRouteValues = New With {.Controller = "Home", .Action = "GridViewUpdatePartial"}
    
            settings.CommandColumn.Visible = True
            settings.CommandColumn.ShowEditButton = True
    
            settings.Columns.Add( _
                Sub(column)
                        column.FieldName = "ProductID"
                        column.ReadOnly = True
                        column.EditFormSettings.Visible = DefaultBoolean.False
                End Sub)

            settings.Columns.Add( _
                Sub(column)
                        column.FieldName = "CategoryID"
                        column.ColumnType = MVCxGridViewColumnType.ComboBox
                        Dim _comboBoxProperties As ComboBoxProperties = CType(column.PropertiesEdit, ComboBoxProperties)
                        _comboBoxProperties.DataSource = NorthwindDataProvider.GetCategories()
                        _comboBoxProperties.TextField = "CategoryName"
                        _comboBoxProperties.ValueField = "CategoryID"
                        _comboBoxProperties.ValueType = GetType(Integer)
                        _comboBoxProperties.ClientSideEvents.SelectedIndexChanged = "OnSelectedIndexChanged"
                        If Convert.ToBoolean(ViewData("hiddenColumnScenario")) Then
                            _comboBoxProperties.TextFormatString = "{0}"
                            _comboBoxProperties.Columns.Add("CategoryName")
                            _comboBoxProperties.Columns.Add("Description").Visible = False
                        End If
                End Sub)

            settings.Columns.Add("ProductName")
            settings.Columns.Add("UnitPrice")
            settings.Columns.Add("UnitsOnOrder")

            settings.ClientSideEvents.BeginCallback = "function(s, e) { e.customArgs['hiddenColumnScenario'] = '" + Convert.ToString(ViewData("hiddenColumnScenario")) + "'; }"

    End Sub).Bind(NorthwindDataProvider.GetProducts()).GetHtml()