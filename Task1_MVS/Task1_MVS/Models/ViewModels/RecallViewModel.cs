using System.Collections.Generic;

namespace Task1_MVS.Models.ViewModels
{
    public class RecallViewModel
    {
        public List<RecallDataViewModel> RecallDatas { get; set; }
            //= StaticRecallDataViewModel.DataForms;

        public RecallDataViewModel FormData { get; set; } = new RecallDataViewModel();
    }
}