using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
namespace MvvmCrossAccordionView
{
    public class AccordionViewModel : MvxViewModel
    {
        public List<string> Items { get; internal set; } = new List<string>(10) { "1", "2", "3", "4", "5" };
    }
}