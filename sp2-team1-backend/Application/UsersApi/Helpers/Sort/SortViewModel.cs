using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UsersApi.Helpers.Sort
{
    public class SortViewModel
    {
        public SortState IdSort { get; private set; }
        public SortState UserNameSort { get; private set; }
        public SortState EmailSort { get; private set; }
        public SortState Current { get; private set; }

        public SortViewModel(SortState sortOrder)
        {
            IdSort = sortOrder == SortState.IdAsc ? SortState.IdDesc : SortState.IdAsc;
            UserNameSort = sortOrder == SortState.EmailAsc ? SortState.EmailDesc : SortState.EmailAsc;
            EmailSort = sortOrder == SortState.EmailAsc ? SortState.EmailDesc: SortState.EmailAsc;
            Current = sortOrder;
        }
    }
}
