using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jhjo.Util.Print;

namespace ShampDesign
{
    public class CEnvironment
    {
        #region SINGLE TON
        private static CEnvironment Src_It = null;


        public static CEnvironment It
        {
            get
            {
                CEnvironment OResult = null;

                try
                {
                    if (CEnvironment.Src_It == null)
                    {
                        CEnvironment.Src_It = new CEnvironment();
                    }

                    OResult = CEnvironment.Src_It;
                }
                catch (Exception ex)
                {
                    CError.Throw(ex);
                }

                return OResult;
            }
        }
        #endregion


        #region PROPERTIES
        public string StrMainRecipe
        {
            get { return this.GetData(CDB.ENVIRONMENT_FEATURE_MAIN_RECIPE); }
            set { this.SetData(CDB.ENVIRONMENT_FEATURE_MAIN_RECIPE, value); }
        }


        public ushort U16NGPort
        {
            get { return Convert.ToUInt16(this.GetData(CDB.ENVIRONMENT_FEATURE_NG_PORT)); }
            set { this.SetData(CDB.ENVIRONMENT_FEATURE_NG_PORT, value.ToString()); }
        }


        public int I32NGInterval
        {
            get { return Convert.ToInt32(this.GetData(CDB.ENVIRONMENT_FEATURE_NG_INTERVAL)); }
            set { this.SetData(CDB.ENVIRONMENT_FEATURE_NG_INTERVAL, value.ToString()); }
        }

        public ushort U16ReadyPort
        {
            get { return Convert.ToUInt16(this.GetData(CDB.ENVIRONMENT_FEATURE_READY_PORT)); }
            set { this.SetData(CDB.ENVIRONMENT_FEATURE_READY_PORT, value.ToString()); }
        }

        public int I32ReadyOnInterval
        {
            get { return Convert.ToInt32(this.GetData(CDB.ENVIRONMENT_FEATURE_READY_ON_INTERVAL)); }
            set { this.SetData(CDB.ENVIRONMENT_FEATURE_READY_ON_INTERVAL, value.ToString()); }
        }

        public int I32ReadyOffInterval
        {
            get { return Convert.ToInt32(this.GetData(CDB.ENVIRONMENT_FEATURE_READY_OFF_INTERVAL)); }
            set { this.SetData(CDB.ENVIRONMENT_FEATURE_READY_OFF_INTERVAL, value.ToString()); }
        }

        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        protected CEnvironment() { }
        #endregion


        #region FUNCTION
        private string GetData(string StrName)
        {
            string StrResult = string.Empty;

            try
            {
                int I32RowIndex = CDB.It[CDB.TABLE_ENVIRONMENT].SelectRowIndex(CDB.ENVIRONMENT_COLUMN_NAME, StrName);
                object OValue = CDB.It[CDB.TABLE_ENVIRONMENT].Select(I32RowIndex, CDB.ENVIRONMENT_COLUMN_VALUE);

                if (OValue != null) StrResult = OValue.ToString();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return StrResult;
        }


        private void SetData(string StrName, object OValue)
        {
            try
            {
                int I32RowIndex = CDB.It[CDB.TABLE_ENVIRONMENT].SelectRowIndex(CDB.ENVIRONMENT_COLUMN_NAME, StrName);
                CDB.It[CDB.TABLE_ENVIRONMENT].Update(I32RowIndex, CDB.ENVIRONMENT_COLUMN_VALUE, OValue.ToString());
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void Commit()
        {
            try
            {
                CDB.It[CDB.TABLE_ENVIRONMENT].Commit();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion
    }
}
