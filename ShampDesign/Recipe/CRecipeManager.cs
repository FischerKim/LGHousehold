using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jhjo.Util.Print;
using Daekhon.Common;
using System.Data;

namespace ShampDesign
{
    public class CRecipeManager
    {
        #region SIGNLE TON
        protected static CRecipeManager Src_It = null;
        public static CRecipeManager It
        {
            get
            {
                CRecipeManager OResult = null;

                try
                {
                    if (CRecipeManager.Src_It == null)
                    {
                        CRecipeManager.Src_It = new CRecipeManager();
                    }

                    OResult = CRecipeManager.Src_It;
                }
                catch (Exception ex)
                {
                    CError.Throw(ex);
                }

                return OResult;
            }
        }
        #endregion


        #region VARIABLE
        private List<IRecipe> m_LstORecipe = null;
        #endregion


        #region PROPERTIES
        public List<IRecipe> LstORecipe
        {
            get { return this.m_LstORecipe; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        protected CRecipeManager()
        {
            try
            {
                this.m_LstORecipe = new List<IRecipe>();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion


        #region FUNCTION
        public bool Load()
        {
            bool BResult = false;

            try
            {
                DataTable ORecipeList = CDB.It[CDB.TABLE_RECIPE_LIST].Select();
                DataTable ORecipeInfo = CDB.It[CDB.TABLE_RECIPE_INFO].Select();

                CShampFaultRecipe ORecipe = null;
                foreach (DataRow _Item1 in ORecipeList.Rows)
                {
                    ORecipe = new CShampFaultRecipe((string)_Item1[CDB.RECIPE_LIST_COLUMN_NAME], (string)_Item1[CDB.RECIPE_LIST_COLUMN_DIRECTORY]);

                    foreach (DataRow _Item2 in ORecipeInfo.Rows)
                    {
                        if ((string)_Item2[CDB.RECIPE_INFO_COLUMN_RECIPE] != ORecipe.StrName) continue;

                        ECAMERA EDirection = (ECAMERA)Enum.Parse(typeof(ECAMERA), (string)_Item2[CDB.RECIPE_INFO_COLUMN_DIRECTION]);
                        switch (EDirection)
                        {
                            case ECAMERA.FRONT_LEFT:
                                ORecipe.OFrontLeft.BEnabled = (bool)_Item2[CDB.RECIPE_INFO_COLUMN_ENABLED];
                                ORecipe.OFrontLeft.F64AngleLow = (double)_Item2[CDB.RECIPE_INFO_COLUMN_ANGLE_LOW];
                                ORecipe.OFrontLeft.F64AngleHigh = (double)_Item2[CDB.RECIPE_INFO_COLUMN_ANGLE_HIGH];
                                ORecipe.OFrontLeft.F64ScaleLow = (double)_Item2[CDB.RECIPE_INFO_COLUMN_SCALE_LOW];
                                ORecipe.OFrontLeft.F64ScaleHigh = (double)_Item2[CDB.RECIPE_INFO_COLUMN_SCALE_HIGH];
                                ORecipe.OFrontLeft.F64MinScore = (double)_Item2[CDB.RECIPE_INFO_COLUMN_MIN_SCORE];
                                break;

                            case ECAMERA.FRONT_RIGHT:
                                ORecipe.OFrontRight.BEnabled = (bool)_Item2[CDB.RECIPE_INFO_COLUMN_ENABLED];
                                ORecipe.OFrontRight.F64AngleLow = (double)_Item2[CDB.RECIPE_INFO_COLUMN_ANGLE_LOW];
                                ORecipe.OFrontRight.F64AngleHigh = (double)_Item2[CDB.RECIPE_INFO_COLUMN_ANGLE_HIGH];
                                ORecipe.OFrontRight.F64ScaleLow = (double)_Item2[CDB.RECIPE_INFO_COLUMN_SCALE_LOW];
                                ORecipe.OFrontRight.F64ScaleHigh = (double)_Item2[CDB.RECIPE_INFO_COLUMN_SCALE_HIGH];
                                ORecipe.OFrontRight.F64MinScore = (double)_Item2[CDB.RECIPE_INFO_COLUMN_MIN_SCORE];
                                break;

                            case ECAMERA.BACK_LEFT:
                                ORecipe.OBackLeft.BEnabled = (bool)_Item2[CDB.RECIPE_INFO_COLUMN_ENABLED];
                                ORecipe.OBackLeft.F64AngleLow = (double)_Item2[CDB.RECIPE_INFO_COLUMN_ANGLE_LOW];
                                ORecipe.OBackLeft.F64AngleHigh = (double)_Item2[CDB.RECIPE_INFO_COLUMN_ANGLE_HIGH];
                                ORecipe.OBackLeft.F64ScaleLow = (double)_Item2[CDB.RECIPE_INFO_COLUMN_SCALE_LOW];
                                ORecipe.OBackLeft.F64ScaleHigh = (double)_Item2[CDB.RECIPE_INFO_COLUMN_SCALE_HIGH];
                                ORecipe.OBackLeft.F64MinScore = (double)_Item2[CDB.RECIPE_INFO_COLUMN_MIN_SCORE];
                                break;

                            case ECAMERA.BACK_RIGHT:
                                ORecipe.OBackRight.BEnabled = (bool)_Item2[CDB.RECIPE_INFO_COLUMN_ENABLED];
                                ORecipe.OBackRight.F64AngleLow = (double)_Item2[CDB.RECIPE_INFO_COLUMN_ANGLE_LOW];
                                ORecipe.OBackRight.F64AngleHigh = (double)_Item2[CDB.RECIPE_INFO_COLUMN_ANGLE_HIGH];
                                ORecipe.OBackRight.F64ScaleLow = (double)_Item2[CDB.RECIPE_INFO_COLUMN_SCALE_LOW];
                                ORecipe.OBackRight.F64ScaleHigh = (double)_Item2[CDB.RECIPE_INFO_COLUMN_SCALE_HIGH];
                                ORecipe.OBackRight.F64MinScore = (double)_Item2[CDB.RECIPE_INFO_COLUMN_MIN_SCORE];
                                break;
                        }
                    }

                    this.m_LstORecipe.Add(ORecipe);
                }

                BResult = true;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return BResult;
        }
        #endregion
    }
}
