/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*	CREXTA - Web Data Extraction Framework  							*
*																		*
*	Copyright (C) 2009-2011  Ahmet BÜTÜN (ahmetbutun@gmail.com)			*
*	http://www.ahmetbutun.net |	http://www.abbsolutions.com				*
*																		*
*	www.me-like.biz														*
*																		*
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *  */
using System;
using System.Linq;

namespace Crexta.Common
{
    public class Common
    {
        public string IndexPath
        {
            get
            {
                return Constants.GeneralConstants.defaultIndexingFileRoot;
            }
        }

        public string RulesPath
        {
            get
            {
                return Constants.GeneralConstants.defaultRulesFileRoot;
            }
        }
    }
}
