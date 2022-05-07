namespace ScheduleLNU.BusinessLogic.DTOs.Comparers
{
    public class ThemeDtoComparer
    {
        public bool Equal(ThemeDto x, ThemeDto y)
        {
            return x.Id == y.Id && x.Title == y.Title
                && x.ForeColor == y.ForeColor && x.BackColor == y.BackColor
                && x.Font == y.Font && x.FontSize == y.FontSize
                && x.IsSelected == y.IsSelected;
        }
    }
}
