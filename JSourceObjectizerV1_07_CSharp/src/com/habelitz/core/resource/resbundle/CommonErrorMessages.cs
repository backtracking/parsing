using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.habelitz.core.resource.resbundle
{
    public sealed class CommonErrorMessages : StringResourceBundle
    {
        private static readonly StringResourceBundle COMMON_ERROR_MESSAGES = 
            (StringResourceBundle)ResourceBundle.getBundle("com.habelitz.core.resource.resbundle.CommonErrorMessages");

        private static readonly String[][] contents = new String[][] { 
        new String[] { "ARG_CONTAINS_NULL", 
        "The argument ''{0}'' must not contain any >null< value." }, 
        new String[] { "ARG_CONTAINS_EMPTY_STRING", 
        "The argument ''{0}'' must not contain the empty string." }, 
        new String[] { "ARG_IS_EMPTY", 
        "The argument ''{0}'' must contain at least one ''{1}''." }, 
        new String[] { "ARG_IS_NULL", "The argument ''{0}'' must not be null." }, 
        new String[] { "ARG_IS_NULL_FOR_CONDITION", 
        "The argument ''{0}'' must not be null if ''{1}''" }, 
        new String[] { "ARG_IS_NOT_NULL_FOR_CONDITION", 
        "The argument ''{0}'' must be null if ''{1}''." }, 
        new String[] { "OFFSET_OUT_OF_BOUNDS", 
        "Invalid offset ''{0}''; the actual range is ''{1}''..''{2}''." }, 
        new String[] { "INVALID_ARG_VALUE", 
        "Invalid value ''{0}'' for the argument ''{1}''." } };

        protected override Object[][] getContents()
        {
            return contents;
        }

        // TODO IMPLEMENTS
        public static String getArgumentContainsNullMessage(String pArgumentIdentifier)
        {
            return "ARG_CONTAINS_NULL";
            //return COMMON_ERROR_MESSAGES.getResource(
            //  "ARG_CONTAINS_NULL", new String[] { pArgumentIdentifier });
        }

        public static String getArgumentContainsEmptyStringMessage(String pArgumentIdentifier)
        {
            return "ARG_CONTAINS_EMPTY_STRING";
            //return COMMON_ERROR_MESSAGES.getResource(
            //  "ARG_CONTAINS_EMPTY_STRING",
            //  new String[] { pArgumentIdentifier });
        }

        public static String getArgumentIsEmptyMessage(String pArgumentIdentifier, String pMissingType)
        {
            return "ARG_IS_EMPTY";
            //return COMMON_ERROR_MESSAGES.getResource(
            //  "ARG_IS_EMPTY",
            //  new String[] { pArgumentIdentifier, pMissingType });
        }

        public static String getArgumentIsNullMessage(String pArgumentIdentifier)
        {
            return "ARG_IS_NULL";
            //return COMMON_ERROR_MESSAGES.getResource(
            //  "ARG_IS_NULL", new String[] { pArgumentIdentifier });
        }

        public static String getArgumentIsNullForConditionMessage(String pArgumentIdentifier, String pCondition)
        {
            return "ARG_IS_NULL_FOR_CONDITION";
            //return COMMON_ERROR_MESSAGES.getResource(
            //  "ARG_IS_NULL_FOR_CONDITION",
            //  new String[] { pArgumentIdentifier, pCondition });
        }

        public static String getArgumentIsNotNullForConditionMessage(String pArgumentIdentifier, String pCondition)
        {
            return "ARG_IS_NOT_NULL_FOR_CONDITION";
            //return COMMON_ERROR_MESSAGES.getResource(
            //  "ARG_IS_NOT_NULL_FOR_CONDITION",
            //  new String[] { pArgumentIdentifier, pCondition });
        }

        public static String getInvalidArgumentValueMessage(String pArgumentIdentifier, String pArgumentValue)
        {
            return "INVALID_ARG_VALUE";
            //return COMMON_ERROR_MESSAGES.getResource(
            //  "INVALID_ARG_VALUE",
            //  new String[] { pArgumentIdentifier, pArgumentValue });
        }

        public static String getOffsetOutOfBoundMessage(int pInvalidOffset, int pLowestOffset, int pHighestOffset)
        {
            return "OFFSET_OUT_OF_BOUNDS";

      //      return COMMON_ERROR_MESSAGES.getResource(
      //        "OFFSET_OUT_OF_BOUNDS",
      //        new String[] { 
      //Convert.ToString(pInvalidOffset), 
      //Convert.ToString(pLowestOffset), 
      //Convert.ToString(pHighestOffset, 2) });
        }
    }
}
