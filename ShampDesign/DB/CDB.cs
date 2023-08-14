using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jhjo.File.DB;
using Jhjo.Util.Print;

namespace ShampDesign
{
    public class CDB : ADB
    {
        #region SIGNLE TON
        protected static CDB Src_It = null;
        public static CDB It
        {
            get
            {
                CDB OResult = null;

                try
                {
                    if (CDB.Src_It == null)
                    {
                        CDB.Src_It = new CDB();
                    }

                    OResult = CDB.Src_It;
                }
                catch (Exception ex)
                {
                    CError.Throw(ex);
                }

                return OResult;
            }
        }
        #endregion


        #region CONST
        public const string TABLE_ENVIRONMENT = "ENVIRONMENT";
        public const string ENVIRONMENT_COLUMN_NAME = "NAME";
        public const string ENVIRONMENT_COLUMN_VALUE = "VALUE";
        public const string ENVIRONMENT_FEATURE_MAIN_RECIPE = "MAIN_RECIPE";
        public const string ENVIRONMENT_FEATURE_NG_PORT = "NG_PORT";
        public const string ENVIRONMENT_FEATURE_NG_INTERVAL = "NG_INTERVAL";
        public const string ENVIRONMENT_FEATURE_READY_PORT = "READY_PORT";
        public const string ENVIRONMENT_FEATURE_READY_ON_INTERVAL = "READY_ON_INTERVAL";
        public const string ENVIRONMENT_FEATURE_READY_OFF_INTERVAL = "READY_OFF_INTERVAL";
        
        public const string TABLE_RECIPE_LIST = "RECIPE_LIST";
        public const string RECIPE_LIST_COLUMN_NAME = "NAME";
        public const string RECIPE_LIST_COLUMN_DIRECTORY = "DIRECTORY";

        public const string TABLE_RECIPE_INFO = "RECIPE_INFO";
        public const string RECIPE_INFO_COLUMN_RECIPE = "RECIPE";
        public const string RECIPE_INFO_COLUMN_DIRECTION = "DIRECTION";
        public const string RECIPE_INFO_COLUMN_ENABLED = "ENABLED";
        public const string RECIPE_INFO_COLUMN_ANGLE_LOW = "ANGLE_LOW";
        public const string RECIPE_INFO_COLUMN_ANGLE_HIGH = "ANGLE_HIGH";
        public const string RECIPE_INFO_COLUMN_SCALE_LOW = "SCALE_LOW";
        public const string RECIPE_INFO_COLUMN_SCALE_HIGH = "SCALE_HIGH";
        public const string RECIPE_INFO_COLUMN_MIN_SCORE = "MIN_SCORE";

        public const string TABLE_REPORT = "REPORT";
        public const string REPORT_COLUMN_DATETIME = "DATETIME";
        public const string REPORT_COLUMN_RECIPE = "RECIPE";
        public const string REPORT_COLUMN_FRONT_LEFT_ENABLE = "FRONT_LEFT_ENABLE";
        public const string REPORT_COLUMN_FRONT_RIGHT_ENABLE = "FRONT_RIGHT_ENABLE";
        public const string REPORT_COLUMN_BACK_LEFT_ENABLE = "BACK_LEFT_ENABLE";
        public const string REPORT_COLUMN_BACK_RIGHT_ENABLE = "BACK_RIGHT_ENABLE";
        public const string REPORT_COLUMN_FRONT_LEFT_MIN = "FRONT_LEFT_MIN";
        public const string REPORT_COLUMN_FRONT_RIGHT_MIN = "FRONT_RIGHT_MIN";
        public const string REPORT_COLUMN_BACK_LEFT_MIN = "BACK_LEFT_MIN";
        public const string REPORT_COLUMN_BACK_RIGHT_MIN = "BACK_RIGHT_MIN";
        public const string REPORT_COLUMN_FRONT_LEFT_SCORE = "FRONT_LEFT_SCORE";
        public const string REPORT_COLUMN_FRONT_RIGHT_SCORE = "FRONT_RIGHT_SCORE";
        public const string REPORT_COLUMN_BACK_LEFT_SCORE = "BACK_LEFT_SCORE";
        public const string REPORT_COLUMN_BACK_RIGHT_SCORE = "BACK_RIGHT_SCORE";
        public const string REPORT_COLUMN_FRONT_LEFT_FILE = "FRONT_LEFT_FILE";
        public const string REPORT_COLUMN_FRONT_RIGHT_FILE = "FRONT_RIGHT_FILE";
        public const string REPORT_COLUMN_BACK_LEFT_FILE = "BACK_LEFT_FILE";
        public const string REPORT_COLUMN_BACK_RIGHT_FILE = "BACK_RIGHT_FILE";

        public const string TABLE_TOOL_RULER = "TOOL_RULER";
        public const string TOOL_RULER_COLUMN_SEQ = "SEQ";
        public const string TOOL_RULER_COLUMN_INDEX = "INDEX";
        public const string TOOL_RULER_COLUMN_CAMERA = "CAMERA";
        #endregion


        #region FUNCTION
        protected override void InitDB() { }
        #endregion
    }
}
