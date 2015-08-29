using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace famiLYNX.Models {
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DataContext> {
    }
}