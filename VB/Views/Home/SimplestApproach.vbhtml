<script type="text/javascript">
    function OnSelectedIndexChanged(s, e) {
        GridView.GetEditor('UnitsOnOrder').SetValue(s.GetValue());
    }
</script>

@Html.Action("GridViewPartial")