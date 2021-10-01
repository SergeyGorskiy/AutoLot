using System.Data.Entity;
using AutoLotDAL.Models;

namespace AutoLotDAL.EF
{
    public class MyDataInitializer : DropCreateDatabaseAlways<AutoLotEntities>
    {
        protected override void Seed(AutoLotEntities context)
        {
            base.Seed(context);
        }
    }
}