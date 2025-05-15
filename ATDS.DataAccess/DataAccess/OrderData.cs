using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATDS.Common;
using ATDS.Common.DatabaseHelper;
using ATDS.Common.Utils;
using ATDS.DataAccess.Entity;

namespace ATDS.DataAccess
{
    public class OrderData
    {
        public OrderData() : base(){ }

        #region Base Function
        /// <summary>
        /// sqlBaseSetSelect
        /// </summary>
        /// <param name="Where"></param>
        /// <param name="Order"></param>
        /// <returns></returns>
        public string sqlBaseSetSelect(string Where, string Order)
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            try
            {
                // SELECT
                sql.Length = 0;                                              // SQL定義
                sql.Append(" SELECT                                                                                     ");
                sql.Append(" 1                                                                                          ");

                sql.Append(" ,IFNULL(ID                            , 0) AS Id                            ");  // Id
                sql.Append(" ,IFNULL(NAME                          , '') AS Name                          ");  // Name
                sql.Append(" ,IFNULL(EXCHANGE_RATE_USD_VND_BUY     , 0) AS ExchangeRateUsdVndBuy         ");  // ExchangeRateUsdVndBuy
                sql.Append(" ,IFNULL(EXCHANGE_RATE_USD_VND_SELL    , 0) AS ExchangeRateUsdVndSell        ");  // ExchangeRateUsdVndSell
                sql.Append(" ,IFNULL(TRANSPORT_METHOD              , 0) AS TransportMethod                ");  // TransportMethod
                sql.Append(" ,IFNULL(PACKING_METHOD                , 0) AS PackingMethod                  ");  // PackingMethod
                sql.Append(" ,IFNULL(WEIGHT_PER_CONTAINER          , '') AS WeightPerContainer            ");  // WeightPerContainer
                sql.Append(" ,IFNULL(ESTIMATED_TOTAL_CONTAINERS     , 0) AS EstimatedTotalContainers        ");  // EstimatedTotalContainers
                sql.Append(" ,IFNULL(ESTIMATED_TOTAL_BOOKINGS      , 0) AS EstimatedTotalBookings         ");  // EstimatedTotalBookings
                sql.Append(" ,IFNULL(BOOKING_NO_CODE               , '') AS BookingNoCode                 ");  // BookingNoCode
                sql.Append(" ,IFNULL(PACKING_DATE                  , '" + Constant.DATE_MIN + "') AS PackingDate                 ");  // PackingDate
                sql.Append(" ,IFNULL(YARD_IN                       , '') AS YardIn                        ");  // YardIn
                sql.Append(" ,IFNULL(TRUCK_PLATE                   , '') AS TruckPlate                    ");  // TruckPlate
                sql.Append(" ,IFNULL(CONTAINER_NO                  , '') AS ContainerNo                   ");  // ContainerNo
                sql.Append(" ,IFNULL(SEAL_NO                       , '') AS SealNo                        ");  // SealNo
                sql.Append(" ,IFNULL(SUPPLIER_NAME                 , '') AS SupplierName                  ");  // SupplierName
                sql.Append(" ,IFNULL(TRANSPORT_COMPANY_NAME        , '') AS TransportCompanyName          ");  // TransportCompanyName
                sql.Append(" ,IFNULL(QUANTITY                      , 0) AS Quantity                        ");  // Quantity
                sql.Append(" ,IFNULL(COATING_COMPANY_NAME          , '') AS CoatingCompanyName            ");  // CoatingCompanyName
                sql.Append(" ,IFNULL(COATED_QUANTITY               , 0) AS CoatedQuantity                 ");  // CoatedQuantity
                sql.Append(" ,IFNULL(PRODUCT_UNIT_PRICE            , 0) AS ProductUnitPrice               ");  // ProductUnitPrice
                sql.Append(" ,IFNULL(COATED_PRODUCT_UNIT_PRICE     , 0) AS CoatedProductUnitPrice         ");  // CoatedProductUnitPrice
                sql.Append(" ,IFNULL(TRANSPORT_UNIT_PRICE          , 0) AS TransportUnitPrice             ");  // TransportUnitPrice
                sql.Append(" ,IFNULL(INVOICE                       , '') AS Invoice                       ");  // Invoice
                sql.Append(" ,IFNULL(PACKING_LIST                  , '') AS PackingList                   ");  // PackingList
                sql.Append(" ,IFNULL(CERTIFICATE_OF_QUALITY        , '') AS CertificateOfQuality          ");  // CertificateOfQuality
                sql.Append(" ,IFNULL(SHIPPING_INSTRUCTION          , '') AS ShippingInstruction           ");  // ShippingInstruction
                sql.Append(" ,IFNULL(VERIFIED_GROSS_MASS           , '') AS VerifiedGrossMass             ");  // VerifiedGrossMass
                sql.Append(" ,IFNULL(TIMBER_PACKING_DECLARATION    , '') AS TimberPackingDeclaration      ");  // TimberPackingDeclaration
                sql.Append(" ,IFNULL(WEIGHING_COST_AT_FACTORY      , 0) AS WeighingCostAtFactory          ");  // WeighingCostAtFactory
                sql.Append(" ,IFNULL(LIFTING_COST                  , 0) AS LiftingCost                    ");  // LiftingCost
                sql.Append(" ,IFNULL(CREATED_AT                    , '" + Constant.DATE_MIN + "') AS CreatedAt                   ");  // CreatedAt
                sql.Append(" ,IFNULL(UPDATED_AT                    , '" + Constant.DATE_MIN + "') AS UpdatedAt                   ");  // UpdatedAt
                sql.Append(" ,IFNULL(YUKO_FLAG                     , 0) AS YukoFlag                       ");  // YukoFlag
                sql.Append(" ,IFNULL(CREATED_USER                  , 0) AS CreatedUser                    ");  // CreatedUser
                sql.Append(" ,IFNULL(LAST_UPDATE_USER              , 0) AS LastUpdateUser                 ");  // LastUpdateUser
                sql.Append(" ,IFNULL(LAST_UPDATE_PROGRAM           , '') AS LastUpdateProgram             ");  // LastUpdateProgram

                sql.Append(" FROM T_ORDER                                                               ");  //   ﾃｰﾌﾞﾙ定義(法人マスタ);
                // Where
                sql.Append(" WHERE 1 = 1                                                                 ");  //   検索条件定義
                if (!string.IsNullOrWhiteSpace(Where))
                {
                    sql.Append(Where);                                                                        //   検索条件定義(ﾕｰｻﾞｰ条件)
                }
                // Order by
                if (!string.IsNullOrWhiteSpace(Order))
                {
                    sql.Append(" ORDER BY                                                                ");  //   並び順定義
                    sql.Append(Order);                                                                        //   並び順(ﾕｰｻﾞｰ条件)
                }

                return sql.ToString();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sql = null;
            }
        }

        /// <summary>
        /// sqlBaseSetSelect - Get Total record
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public string sqlBaseSetSelectTotalRecord(string Where)
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            try
            {
                // SELECT
                sql.Length = 0;                                              // SQL定義
                sql.Append(" SELECT  COUNT(1) AS NUM_RECORDS                                             ");
                sql.Append(" FROM T_ORDER                                                   ");  //   ﾃｰﾌﾞﾙ定義(法人マスタ);
                // Where
                sql.Append(" WHERE 1 = 1                                                                 ");  //   検索条件定義
                if (!string.IsNullOrWhiteSpace(Where))
                {
                    sql.Append(Where);                                                                        //   検索条件定義(ﾕｰｻﾞｰ条件)
                }

                return sql.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// sqlBaseSetSelect
        /// </summary>
        /// <param name="Where"></param>
        /// <param name="Order"></param>
        /// <param name="iPage"></param>
        /// <param name="iRecordOfPage"></param>
        /// <returns></returns>
        public string sqlBaseSetSelectPage(string Where, string Order, int iPage, int iRecordOfPage)
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            try
            {
                // SELECT
                sql.Length = 0;                                              // SQL定義
                sql.Append(" SELECT                                                                                     ");
                sql.Append(" 1                                                                                          ");
                sql.Append(" ,IFNULL(ID                            , 0) AS Id                            ");  // Id
                sql.Append(" ,IFNULL(NAME                          , '') AS Name                          ");  // Name
                sql.Append(" ,IFNULL(EXCHANGE_RATE_USD_VND_BUY     , 0) AS ExchangeRateUsdVndBuy         ");  // ExchangeRateUsdVndBuy
                sql.Append(" ,IFNULL(EXCHANGE_RATE_USD_VND_SELL    , 0) AS ExchangeRateUsdVndSell        ");  // ExchangeRateUsdVndSell
                sql.Append(" ,IFNULL(TRANSPORT_METHOD              , 0) AS TransportMethod                ");  // TransportMethod
                sql.Append(" ,IFNULL(PACKING_METHOD                , 0) AS PackingMethod                  ");  // PackingMethod
                sql.Append(" ,IFNULL(WEIGHT_PER_CONTAINER          , '') AS WeightPerContainer            ");  // WeightPerContainer
                sql.Append(" ,IFNULL(ESTIMATED_TOTAL_CONTAINERS     , 0) AS EstimatedTotalContainers        ");  // EstimatedTotalContainers
                sql.Append(" ,IFNULL(ESTIMATED_TOTAL_BOOKINGS      , 0) AS EstimatedTotalBookings         ");  // EstimatedTotalBookings
                sql.Append(" ,IFNULL(BOOKING_NO_CODE               , '') AS BookingNoCode                 ");  // BookingNoCode
                sql.Append(" ,IFNULL(PACKING_DATE                  , '" + Constant.DATE_MIN + "') AS PackingDate                 ");  // PackingDate
                sql.Append(" ,IFNULL(YARD_IN                       , '') AS YardIn                        ");  // YardIn
                sql.Append(" ,IFNULL(TRUCK_PLATE                   , '') AS TruckPlate                    ");  // TruckPlate
                sql.Append(" ,IFNULL(CONTAINER_NO                  , '') AS ContainerNo                   ");  // ContainerNo
                sql.Append(" ,IFNULL(SEAL_NO                       , '') AS SealNo                        ");  // SealNo
                sql.Append(" ,IFNULL(SUPPLIER_NAME                 , '') AS SupplierName                  ");  // SupplierName
                sql.Append(" ,IFNULL(TRANSPORT_COMPANY_NAME        , '') AS TransportCompanyName          ");  // TransportCompanyName
                sql.Append(" ,IFNULL(QUANTITY                      , 0) AS Quantity                        ");  // Quantity
                sql.Append(" ,IFNULL(COATING_COMPANY_NAME          , '') AS CoatingCompanyName            ");  // CoatingCompanyName
                sql.Append(" ,IFNULL(COATED_QUANTITY               , 0) AS CoatedQuantity                 ");  // CoatedQuantity
                sql.Append(" ,IFNULL(PRODUCT_UNIT_PRICE            , 0) AS ProductUnitPrice               ");  // ProductUnitPrice
                sql.Append(" ,IFNULL(COATED_PRODUCT_UNIT_PRICE     , 0) AS CoatedProductUnitPrice         ");  // CoatedProductUnitPrice
                sql.Append(" ,IFNULL(TRANSPORT_UNIT_PRICE          , 0) AS TransportUnitPrice             ");  // TransportUnitPrice
                sql.Append(" ,IFNULL(INVOICE                       , '') AS Invoice                       ");  // Invoice
                sql.Append(" ,IFNULL(PACKING_LIST                  , '') AS PackingList                   ");  // PackingList
                sql.Append(" ,IFNULL(CERTIFICATE_OF_QUALITY        , '') AS CertificateOfQuality          ");  // CertificateOfQuality
                sql.Append(" ,IFNULL(SHIPPING_INSTRUCTION          , '') AS ShippingInstruction           ");  // ShippingInstruction
                sql.Append(" ,IFNULL(VERIFIED_GROSS_MASS           , '') AS VerifiedGrossMass             ");  // VerifiedGrossMass
                sql.Append(" ,IFNULL(TIMBER_PACKING_DECLARATION    , '') AS TimberPackingDeclaration      ");  // TimberPackingDeclaration
                sql.Append(" ,IFNULL(WEIGHING_COST_AT_FACTORY      , 0) AS WeighingCostAtFactory          ");  // WeighingCostAtFactory
                sql.Append(" ,IFNULL(LIFTING_COST                  , 0) AS LiftingCost                    ");  // LiftingCost
                sql.Append(" ,IFNULL(CREATED_AT                    , '" + Constant.DATE_MIN + "') AS CreatedAt                   ");  // CreatedAt
                sql.Append(" ,IFNULL(UPDATED_AT                    , '" + Constant.DATE_MIN + "') AS UpdatedAt                   ");  // UpdatedAt
                sql.Append(" ,IFNULL(YUKO_FLAG                     , 0) AS YukoFlag                       ");  // YukoFlag
                sql.Append(" ,IFNULL(CREATED_USER                  , 0) AS CreatedUser                    ");  // CreatedUser
                sql.Append(" ,IFNULL(LAST_UPDATE_USER              , 0) AS LastUpdateUser                 ");  // LastUpdateUser
                sql.Append(" ,IFNULL(LAST_UPDATE_PROGRAM           , '') AS LastUpdateProgram             ");  // LastUpdateProgram

                sql.Append(" FROM T_ORDER                                                               ");  //   ﾃｰﾌﾞﾙ定義(法人マスタ);
                // Where
                sql.Append(" WHERE 1 = 1                                                                 ");  //   検索条件定義
                if (!string.IsNullOrWhiteSpace(Where))
                {
                    sql.Append(Where);                                                                        //   検索条件定義(ﾕｰｻﾞｰ条件)
                }
                // Order by
                if (!string.IsNullOrWhiteSpace(Order))
                {
                    sql.Append(" ORDER BY                                                                ");  //   並び順定義
                    sql.Append(Order);                                                                        //   並び順(ﾕｰｻﾞｰ条件)
                }
                // Get Record of page
                sql.Append(" LIMIT " + iRecordOfPage + " OFFSET " + (iPage - 1) * iRecordOfPage);

                return sql.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// sqlBaseSetInsert
        /// </summary>
        /// <param name="cls"></param>
        /// <param name="vstrUpdateUser"></param>
        /// <param name="vstrUpdateProgram"></param>
        /// <returns></returns>
        public string sqlBaseSetInsert(OrderEntity cls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            try
            {
                // INSERT
                sql.Length = 0;                                              // SQL定義
                sql.Append(" INSERT INTO T_ORDER (              ");
                sql.Append("   NAME                             ");  // Name
                sql.Append("  ,EXCHANGE_RATE_USD_VND_BUY        ");  // ExchangeRateUsdVndBuy
                sql.Append("  ,EXCHANGE_RATE_USD_VND_SELL       ");  // ExchangeRateUsdVndSell
                sql.Append("  ,TRANSPORT_METHOD                 ");  // TransportMethod
                sql.Append("  ,PACKING_METHOD                   ");  // PackingMethod
                sql.Append("  ,WEIGHT_PER_CONTAINER             ");  // WeightPerContainer
                sql.Append("  ,ESTIMATED_TOTAL_CONTAINERS        ");  // EstimatedTotalContainers
                sql.Append("  ,ESTIMATED_TOTAL_BOOKINGS         ");  // EstimatedTotalBookings
                sql.Append("  ,BOOKING_NO_CODE                  ");  // BookingNoCode
                sql.Append("  ,PACKING_DATE                     ");  // PackingDate
                sql.Append("  ,YARD_IN                          ");  // YardIn
                sql.Append("  ,TRUCK_PLATE                      ");  // TruckPlate
                sql.Append("  ,CONTAINER_NO                     ");  // ContainerNo
                sql.Append("  ,SEAL_NO                          ");  // SealNo
                sql.Append("  ,SUPPLIER_NAME                    ");  // SupplierName
                sql.Append("  ,TRANSPORT_COMPANY_NAME           ");  // TransportCompanyName
                sql.Append("  ,QUANTITY                         ");  // Quantity
                sql.Append("  ,COATING_COMPANY_NAME             ");  // CoatingCompanyName
                sql.Append("  ,COATED_QUANTITY                  ");  // CoatedQuantity
                sql.Append("  ,PRODUCT_UNIT_PRICE               ");  // ProductUnitPrice
                sql.Append("  ,COATED_PRODUCT_UNIT_PRICE        ");  // CoatedProductUnitPrice
                sql.Append("  ,TRANSPORT_UNIT_PRICE             ");  // TransportUnitPrice
                sql.Append("  ,INVOICE                          ");  // Invoice
                sql.Append("  ,PACKING_LIST                     ");  // PackingList
                sql.Append("  ,CERTIFICATE_OF_QUALITY           ");  // CertificateOfQuality
                sql.Append("  ,SHIPPING_INSTRUCTION             ");  // ShippingInstruction
                sql.Append("  ,VERIFIED_GROSS_MASS              ");  // VerifiedGrossMass
                sql.Append("  ,TIMBER_PACKING_DECLARATION       ");  // TimberPackingDeclaration
                sql.Append("  ,WEIGHING_COST_AT_FACTORY         ");  // WeighingCostAtFactory
                sql.Append("  ,LIFTING_COST                     ");  // LiftingCost
                sql.Append("  ,CREATED_AT                       ");  // CreatedAt
                sql.Append("  ,UPDATED_AT                       ");  // UpdatedAt
                sql.Append("  ,YUKO_FLAG                        ");  // YukoFlag
                sql.Append("  ,CREATED_USER                     ");  // CreatedUser
                sql.Append("  ,LAST_UPDATE_USER                 ");  // LastUpdateUser
                sql.Append("  ,LAST_UPDATE_PROGRAM              ");  // LastUpdateProgram
                sql.Append(" )                                  ");

                sql.Append(" VALUES (                           ");
                sql.Append("   @Name                            ");  // Name
                sql.Append("  ,@ExchangeRateUsdVndBuy          ");  // ExchangeRateUsdVndBuy
                sql.Append("  ,@ExchangeRateUsdVndSell         ");  // ExchangeRateUsdVndSell
                sql.Append("  ,@TransportMethod                ");  // TransportMethod
                sql.Append("  ,@PackingMethod                  ");  // PackingMethod
                sql.Append("  ,@WeightPerContainer             ");  // WeightPerContainer
                sql.Append("  ,@EstimatedTotalContainers        ");  // EstimatedTotalContainers
                sql.Append("  ,@EstimatedTotalBookings         ");  // EstimatedTotalBookings
                sql.Append("  ,@BookingNoCode                  ");  // BookingNoCode
                sql.Append("  ,@PackingDate                    ");  // PackingDate
                sql.Append("  ,@YardIn                         ");  // YardIn
                sql.Append("  ,@TruckPlate                     ");  // TruckPlate
                sql.Append("  ,@ContainerNo                    ");  // ContainerNo
                sql.Append("  ,@SealNo                         ");  // SealNo
                sql.Append("  ,@SupplierName                   ");  // SupplierName
                sql.Append("  ,@TransportCompanyName          ");  // TransportCompanyName
                sql.Append("  ,@Quantity                       ");  // Quantity
                sql.Append("  ,@CoatingCompanyName            ");  // CoatingCompanyName
                sql.Append("  ,@CoatedQuantity                 ");  // CoatedQuantity
                sql.Append("  ,@ProductUnitPrice              ");  // ProductUnitPrice
                sql.Append("  ,@CoatedProductUnitPrice        ");  // CoatedProductUnitPrice
                sql.Append("  ,@TransportUnitPrice            ");  // TransportUnitPrice
                sql.Append("  ,@Invoice                        ");  // Invoice
                sql.Append("  ,@PackingList                   ");  // PackingList
                sql.Append("  ,@CertificateOfQuality          ");  // CertificateOfQuality
                sql.Append("  ,@ShippingInstruction           ");  // ShippingInstruction
                sql.Append("  ,@VerifiedGrossMass             ");  // VerifiedGrossMass
                sql.Append("  ,@TimberPackingDeclaration      ");  // TimberPackingDeclaration
                sql.Append("  ,@WeighingCostAtFactory         ");  // WeighingCostAtFactory
                sql.Append("  ,@LiftingCost                   ");  // LiftingCost
                sql.Append("  ,@CreatedAt                     ");  // CreatedAt
                sql.Append("  ,@UpdatedAt                     ");  // UpdatedAt
                sql.Append("  ,@YukoFlag                      ");  // YukoFlag
                sql.Append("  ,@CreatedUser                   ");  // CreatedUser
                sql.Append("  ,@LastUpdateUser               ");   // LastUpdateUser
                sql.Append("  ,@LastUpdateProgram            ");   // LastUpdateProgram
                sql.Append(" );                               ");
                sql.Append(" SELECT LAST_INSERT_ID();         ");  // Lấy ID tự động tăng sau khi insert


                return sql.ToString();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
        }

        /// <summary>
        /// sqlBaseSetUpdate
        /// </summary>
        /// <param name="cls"></param>
        /// <param name="vstrUpdateUser"></param>
        /// <param name="vstrUpdateProgram"></param>
        /// <returns></returns>
        public string sqlBaseSetUpdate(OrderEntity cls, string vstrUpdateUser, string vstrUpdateProgram)
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            try
            {
                sql.Length = 0;                                                  // SQL定義
                sql.Append(" UPDATE T_ORDER SET                             ");
                sql.Append("   NAME                        = @Name                        ");  // Name
                sql.Append("  ,EXCHANGE_RATE_USD_VND_BUY  = @ExchangeRateUsdVndBuy       ");  // ExchangeRateUsdVndBuy
                sql.Append("  ,EXCHANGE_RATE_USD_VND_SELL = @ExchangeRateUsdVndSell      ");  // ExchangeRateUsdVndSell
                sql.Append("  ,TRANSPORT_METHOD           = @TransportMethod             ");  // TransportMethod
                sql.Append("  ,PACKING_METHOD             = @PackingMethod               ");  // PackingMethod
                sql.Append("  ,WEIGHT_PER_CONTAINER       = @WeightPerContainer          ");  // WeightPerContainer
                sql.Append("  ,ESTIMATED_TOTAL_CONTAINERS  = @EstimatedTotalContainers     ");  // EstimatedTotalContainers
                sql.Append("  ,ESTIMATED_TOTAL_BOOKINGS   = @EstimatedTotalBookings      ");  // EstimatedTotalBookings
                sql.Append("  ,BOOKING_NO_CODE            = @BookingNoCode               ");  // BookingNoCode
                sql.Append("  ,PACKING_DATE               = @PackingDate                 ");  // PackingDate
                sql.Append("  ,YARD_IN                    = @YardIn                      ");  // YardIn
                sql.Append("  ,TRUCK_PLATE                = @TruckPlate                  ");  // TruckPlate
                sql.Append("  ,CONTAINER_NO               = @ContainerNo                 ");  // ContainerNo
                sql.Append("  ,SEAL_NO                    = @SealNo                      ");  // SealNo
                sql.Append("  ,SUPPLIER_NAME              = @SupplierName                ");  // SupplierName
                sql.Append("  ,TRANSPORT_COMPANY_NAME     = @TransportCompanyName        ");  // TransportCompanyName
                sql.Append("  ,QUANTITY                   = @Quantity                    ");  // Quantity
                sql.Append("  ,COATING_COMPANY_NAME       = @CoatingCompanyName          ");  // CoatingCompanyName
                sql.Append("  ,COATED_QUANTITY            = @CoatedQuantity              ");  // CoatedQuantity
                sql.Append("  ,PRODUCT_UNIT_PRICE         = @ProductUnitPrice            ");  // ProductUnitPrice
                sql.Append("  ,COATED_PRODUCT_UNIT_PRICE  = @CoatedProductUnitPrice      ");  // CoatedProductUnitPrice
                sql.Append("  ,TRANSPORT_UNIT_PRICE       = @TransportUnitPrice          ");  // TransportUnitPrice
                sql.Append("  ,INVOICE                    = @Invoice                     ");  // Invoice
                sql.Append("  ,PACKING_LIST               = @PackingList                 ");  // PackingList
                sql.Append("  ,CERTIFICATE_OF_QUALITY     = @CertificateOfQuality        ");  // CertificateOfQuality
                sql.Append("  ,SHIPPING_INSTRUCTION       = @ShippingInstruction         ");  // ShippingInstruction
                sql.Append("  ,VERIFIED_GROSS_MASS        = @VerifiedGrossMass           ");  // VerifiedGrossMass
                sql.Append("  ,TIMBER_PACKING_DECLARATION = @TimberPackingDeclaration    ");  // TimberPackingDeclaration
                sql.Append("  ,WEIGHING_COST_AT_FACTORY   = @WeighingCostAtFactory       ");  // WeighingCostAtFactory
                sql.Append("  ,LIFTING_COST               = @LiftingCost                 ");  // LiftingCost
                sql.Append("  ,CREATED_AT                 = @CreatedAt                   ");  // CreatedAt
                sql.Append("  ,UPDATED_AT                 = @UpdatedAt                   ");  // UpdatedAt
                sql.Append("  ,YUKO_FLAG                  = @YukoFlag                    ");  // YukoFlag
                sql.Append("  ,CREATED_USER               = @CreatedUser                 ");  // CreatedUser
                sql.Append("  ,LAST_UPDATE_USER           = @LastUpdateUser              ");  // LastUpdateUser
                sql.Append("  ,LAST_UPDATE_PROGRAM        = @LastUpdateProgram           ");  // LastUpdateProgram

                sql.Append(" WHERE ID = @Id                                                 ");  //  検索条件定義

                return sql.ToString();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
        }

        /// <summary>
        /// sqlBaseSetUpdate
        /// </summary>        /// <param name="ID"></param>
        /// <param name="vstrUpdateUser"></param>
        /// <param name="vstrUpdateProgram"></param>
        /// <returns></returns>
        public string sqlBaseSetDelete(int piId,
                                       string vstrUpdateUser,
                                       string vstrUpdateProgram)
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            try
            {
                sql.Append(" UPDATE  T_ORDER                                                                         ");
                sql.Append(" SET YUKO_FLAG                  =    " + (int)Constant.YUKO_FLAG.DISABLED + "         ,");
                sql.Append("     LAST_UPDATE_USER           =    '" + vstrUpdateUser + "'                    ,");
                sql.Append("     LAST_UPDATE_PROGRAM        =   '" + vstrUpdateProgram + "'                  ");
                sql.Append(" WHERE ID                       = @Id                            ");  //   検索条件定義

                sql.Append(" AND YUKO_FLAG                  =    " + (int)Constant.YUKO_FLAG.ENABLED);

                return sql.ToString();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }
        #endregion

        #region GetData
        /// <summary>
        /// GetDataSet
        /// </summary>
        /// <param name="Sdr"></param>
        /// <returns></returns>
        private OrderEntity GetDataSet(IDataReader Sdr)
        {
            OrderEntity order = new OrderEntity();                                  // Orderｸﾗｽ定義   

            try
            {
                order = new OrderEntity();                                   // T_ORDER　ｸﾗｽ初期化

                {
                    var withBlock = order;                                               // @@@Table.NAME情報格納
                    withBlock.Id = Convert.ToInt32(Sdr["Id"]);
                    withBlock.Name = Sdr["Name"]?.ToString()?.Trim();
                    withBlock.ExchangeRateUsdVndBuy = Sdr["ExchangeRateUsdVndBuy"] as decimal?;
                    withBlock.ExchangeRateUsdVndSell = Sdr["ExchangeRateUsdVndSell"] as decimal?;
                    withBlock.TransportMethod = Convert.ToInt32(Sdr["TransportMethod"]);
                    withBlock.PackingMethod = Convert.ToInt32(Sdr["PackingMethod"]);
                    withBlock.WeightPerContainer = Sdr["WeightPerContainer"]?.ToString()?.Trim();
                    withBlock.EstimatedTotalContainers = Sdr["EstimatedTotalContainers"] as decimal?;
                    withBlock.EstimatedTotalBookings = Sdr["EstimatedTotalBookings"] as decimal?;
                    withBlock.BookingNoCode = Sdr["BookingNoCode"]?.ToString()?.Trim();
                    withBlock.PackingDate = Convert.ToDateTime(Sdr["PackingDate"]);
                    withBlock.YardIn = Sdr["YardIn"]?.ToString()?.Trim();
                    withBlock.TruckPlate = Sdr["TruckPlate"]?.ToString()?.Trim();
                    withBlock.ContainerNo = Sdr["ContainerNo"]?.ToString()?.Trim();
                    withBlock.SealNo = Sdr["SealNo"]?.ToString()?.Trim();
                    withBlock.SupplierName = Sdr["SupplierName"]?.ToString()?.Trim();
                    withBlock.TransportCompanyName = Sdr["TransportCompanyName"]?.ToString()?.Trim();
                    withBlock.Quantity = Sdr["Quantity"] as decimal?;
                    withBlock.CoatingCompanyName = Sdr["CoatingCompanyName"]?.ToString()?.Trim();
                    withBlock.CoatedQuantity = Sdr["CoatedQuantity"] as decimal?;
                    withBlock.ProductUnitPrice = Sdr["ProductUnitPrice"] as decimal?;
                    withBlock.CoatedProductUnitPrice = Sdr["CoatedProductUnitPrice"] as decimal?;
                    withBlock.TransportUnitPrice = Sdr["TransportUnitPrice"] as decimal?;
                    withBlock.Invoice = Sdr["Invoice"]?.ToString()?.Trim();
                    withBlock.PackingList = Sdr["PackingList"]?.ToString()?.Trim();
                    withBlock.CertificateOfQuality = Sdr["CertificateOfQuality"]?.ToString()?.Trim();
                    withBlock.ShippingInstruction = Sdr["ShippingInstruction"]?.ToString()?.Trim();
                    withBlock.VerifiedGrossMass = Sdr["VerifiedGrossMass"]?.ToString()?.Trim();
                    withBlock.TimberPackingDeclaration = Sdr["TimberPackingDeclaration"]?.ToString()?.Trim();
                    withBlock.WeighingCostAtFactory = Sdr["WeighingCostAtFactory"] as decimal?;
                    withBlock.LiftingCost = Sdr["LiftingCost"] as decimal?;
                    withBlock.CreatedAt = Convert.ToDateTime(Sdr["CreatedAt"]);
                    withBlock.UpdatedAt = Convert.ToDateTime(Sdr["UpdatedAt"]);
                    withBlock.YukoFlag = Convert.ToInt32(Sdr["YukoFlag"]);
                    withBlock.CreatedUser = Convert.ToInt32(Sdr["CreatedUser"]);
                    withBlock.LastUpdateUser = Convert.ToInt32(Sdr["LastUpdateUser"]);
                    withBlock.LastUpdateProgram = Sdr["LastUpdateProgram"]?.ToString()?.Trim();

                }

                return order;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }// SQLServerDataRead初期化
        }

        #endregion

        #region 【メソッド】 CheckData
        #endregion

        #region Insert - Update - Delete
        public ReturnInfo Insert(MySQLServerHelper Con, ref OrderEntity vCls, List<IDbDataParameter> lstParameter, string vstrUpdateUser, string vstrUpdateProgram)
        {
            string sql = "";
            string where = "";
            string order = "";
            OrderEntity objCls = new OrderEntity();
            ReturnInfo ret = new ReturnInfo();

            // --- Begin transaction
            // Con.BeginTrans();

            try
            {
                sql = "";
                where = "";
                order = "";

                // --- 登録データ設定
                if (vCls != null) objCls = vCls;

                // --- SQL設定
                sql = sqlBaseSetInsert(objCls, vstrUpdateUser, vstrUpdateProgram);

                // --- SQL実行
                Con.ExecuteSQLWithParams(sql, lstParameter);

                {
                    var withBlock = ret;
                    withBlock.State = true;
                    withBlock.Code = 0;
                    withBlock.Message = string.Empty;
                }

                // --- Commit transaction
                // Con.Commit();

                return ret;
            }
            catch (Exception ex)
            {
                // --- Rollback transaction
                // Con.Rollback();

                {
                    var withBlock = ret;
                    withBlock.State = false;
                    withBlock.Code = ex.HResult;
                    withBlock.Message = ex.Message;
                }
            }
            finally
            {
            }

            return ret;
        }

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="vCls"></param>
        /// <returns></returns>
        public ReturnInfo Update(MySQLServerHelper Con, ref OrderEntity vCls, List<IDbDataParameter> lstParameter, string vstrUpdateUser, string vstrUpdateProgram)
        {
            string sql = "";
            OrderEntity objCls = new OrderEntity();
            ReturnInfo ret = new ReturnInfo();

            // --- Begin transaction
            // Con.BeginTrans();

            try
            {
                sql = "";

                // --- 登録データ設定
                if (vCls != null)
                    objCls = vCls;

                // --- SQL設定
                sql = sqlBaseSetUpdate(objCls, vstrUpdateUser, vstrUpdateProgram);

                // --- SQL実行
                Con.ExecuteSQLWithParams(sql, lstParameter);

                {
                    var withBlock = ret;
                    withBlock.State = true;
                    withBlock.Code = 0;
                    withBlock.Message = string.Empty;
                }

                // --- Commit transaction
                // Con.Commit();

                return ret;
            }
            catch (Exception ex)
            {
                // --- Rollback transaction
                // Con.Rollback();

                {
                    var withBlock = ret;
                    withBlock.State = false;
                    withBlock.Code = ex.HResult;
                    withBlock.Message = ex.Message;
                }
            }
            finally
            {
            }

            return ret;
        }

        /// <summary>
        /// データを削除
        /// </summary>
        /// <param name="vCls"></param>
        /// <returns></returns>
        public ReturnInfo Delete(MySQLServerHelper con, int piId, string vstrUpdateUser, string vstrUpdateProgram)
        {
            string sql;
            List<IDbDataParameter> Params = new List<IDbDataParameter>();
            ReturnInfo ret = new ReturnInfo();

            try
            {
                sql = "";

                // --- SQL設定
                sql = sqlBaseSetDelete(piId, vstrUpdateUser, vstrUpdateProgram);

                Params.Add(DBUtils.CreateParam("@Id", piId));  // Id

                //--- SQL実行
                con.ExecuteSQLWithParams(sql, Params);

                {
                    var withBlock = ret;
                    withBlock.State = true;
                    withBlock.Code = 0;
                    withBlock.Message = string.Empty;
                }

                return ret;
            }
            catch (Exception ex)
            {
                // --- Rollback transaction
                // con.Rollback();

                {
                    var withBlock = ret;
                    withBlock.State = false;
                    withBlock.Code = ex.HResult;
                    withBlock.Message = ex.Message;
                }
            }
            finally
            {
            }

            return ret;
        }
        #endregion

        #region【一覧取得】 Search
        public List<OrderEntity> Search(MySQLServerHelper con, string where, List<IDbDataParameter> lstParameter, string order)
        {
            string sql = "";
            IDataReader Sdr;
            OrderEntity objCls = new OrderEntity();
            List<OrderEntity> lstOrderEntity = new List<OrderEntity>();

            try
            {
                //--- SQL設定
                sql = sqlBaseSetSelect(where, order);

                //--- 情報取得
                Sdr = con.SelectSQLWithParams(sql, lstParameter);

                using (Sdr)
                {

                    while (Sdr.Read())
                    {
                        lstOrderEntity.Add(GetDataSet(Sdr));
                    }
                }

                return lstOrderEntity;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
        }
        #endregion
        #region 【一覧取得】 Search Page
        public PaginatedList<OrderEntity> SearchPage(MySQLServerHelper con,
                                            string where,
                                            List<IDbDataParameter> lstParameter,
                                            string order,
                                            int iPage = 1,
                                            int iSize = 20)
        {
            string sql = "";
            IDataReader Sdr;
            OrderEntity objCls = new OrderEntity();
            List<OrderEntity> lstOrderEntity = new List<OrderEntity>();

            try
            {
                //--- Get total record
                sql = sqlBaseSetSelectTotalRecord(where);
                Sdr = con.SelectSQLWithParams(sql, lstParameter.ToList());
                var iTotalRecord = 0;
                using (Sdr)
                {
                    Sdr.Read();
                    iTotalRecord = System.Convert.ToInt32(Sdr["NUM_RECORDS"]);
                }
                if (iTotalRecord > 0)
                {
                    //--- SQL設定
                    sql = sqlBaseSetSelectPage(where, order, iPage, iSize);

                    //--- 情報取得                    
                    Sdr = con.SelectSQLWithParams(sql, lstParameter.ToList());

                    using (Sdr)
                    {

                        while (Sdr.Read())
                        {
                            lstOrderEntity.Add(GetDataSet(Sdr));
                        }
                    }
                }

                return new PaginatedList<OrderEntity>(lstOrderEntity, iTotalRecord, iPage, iSize);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
        }
        #endregion
        
        #region 【一覧取得】 SearchByKey
        public List<OrderEntity> SearchByKey(MySQLServerHelper con, int piId)
        {
            string sql = "";
            string where = "";
            string order = "";
            IDataReader Sdr;
            List<IDbDataParameter> Params = new List<IDbDataParameter>();
            OrderEntity objCls = new OrderEntity();
            List<OrderEntity> lstOrderEntity = new List<OrderEntity>();

            try
            {

                //--- 条件設定
                if (piId != -1)
                {
                    where += "AND ID = @Id";
                }

                //--- SQL Params
                if (piId != -1)
                {
                    Params.Add(DBUtils.CreateParam("@Id", piId));
                }

                //--- SQL設定
                sql = sqlBaseSetSelect(where, order);

                //--- 情報取得
                Sdr = con.SelectSQLWithParams(sql, Params);

                using (Sdr)
                {

                    while (Sdr.Read())
                    {
                        lstOrderEntity.Add(GetDataSet(Sdr));
                    }
                }

                return lstOrderEntity;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
        }
        #endregion
    }
}
