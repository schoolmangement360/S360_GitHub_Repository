using S360.View.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S360
{
    public static class ShowUserControl
    {
        public static object ShowUserControlAndSetVM(int pageID)
        {
            switch (pageID)
            {
                //// File ///
                case 101:
                    break;
                case 102:
                    break;
                case 103:
                    break;
                case 104:
                    break;
                case 105:
                    break;
                case 106:
                    break;
                case 107:
                    break;
                case 108:
                    break;
                case 109:
                    break;
                case 110:
                    break;
                case 111:
                    break;
                case 112:
                    break;
                case 113:
                    break;
                case 114:
                    break;
                case 115:
                    break;
                case 116:
                    break;
                case 117:
                    break;
                case 118:
                    break;
                case 119:
                    break;
                case 120:
                    break;

                //// Masters ///
                case 201:
                    break;
                case 202:
                    break;
                case 203:
                    break;
                case 204:
                    break;
                case 205:
                    break;
                case 206:
                    break;
                case 207:
                    break;
                case 208:
                    break;
                case 209:
                    break;
                case 210:
                    break;
                case 211:
                    break;
                case 212:
                    break;
                case 213:
                    break;
                case 214:
                    break;
                case 215:
                    break;
                case 216:
                    break;
                case 217:
                    break;
                case 218:
                    break;
                case 219:
                    break;
                case 220:
                    break;

                //// Cheques ///
                case 301:
                    break;
                case 302:
                    break;
                case 303:
                    break;
                case 304:
                    break;
                case 305:
                    break;
                case 306:
                    break;
                case 307:
                    break;
                case 308:
                    break;
                case 309:
                    break;
                case 310:
                    break;
                case 311:
                    break;
                case 312:
                    break;
                case 313:
                    break;
                case 314:
                    break;
                case 315:
                    break;
                case 316:
                    break;
                case 317:
                    break;
                case 318:
                    break;
                case 319:
                    break;
                case 320:
                    break;

                //// Reciepts ///
                case 401:
                    break;
                case 402:
                    break;
                case 403:
                    break;
                case 404:
                    break;
                case 405:
                    break;
                case 406:
                    break;
                case 407:
                    break;
                case 408:
                    break;
                case 409:
                    break;
                case 410:
                    break;
                case 411:
                    break;
                case 412:
                    break;
                case 413:
                    break;
                case 414:
                    break;
                case 415:
                    break;
                case 416:
                    break;
                case 417:
                    break;
                case 418:
                    break;
                case 419:
                    break;
                case 420:

                //// Students ///
                case 501:
                    return new UC_AddStudentScreen();
                case 502:
                    break;
                case 503:
                    break;
                case 504:
                    break;
                case 505:
                    break;
                case 506:
                    break;
                case 507:
                    break;
                case 508:
                    break;
                case 509:
                    break;
                case 510:
                    break;
                case 511:
                    break;
                case 512:
                    break;
                case 513:
                    break;
                case 514:
                    break;
                case 515:
                    break;
                case 516:
                    break;
                case 517:
                    return new UC_AllotDivisionScreen();
                case 518:
                    return new UC_StudentTCScreen();
                case 519:
                    break;
                case 520:

                default:
                    break;
            }

            return null;
        }
    }
}
