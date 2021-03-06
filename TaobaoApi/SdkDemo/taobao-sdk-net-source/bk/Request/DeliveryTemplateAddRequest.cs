using System;
using System.Collections.Generic;
using Top.Api.Response;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.delivery.template.add
    /// </summary>
    public class DeliveryTemplateAddRequest : ITopRequest<DeliveryTemplateAddResponse>
    {
        /// <summary>
        /// 可选值：0,1 <br>  说明<br>0:表示买家承担服务费;<br>1:表示卖家承担服务费
        /// </summary>
        public Nullable<long> Assumer { get; set; }

        /// <summary>
        /// 运费模板的名称，长度不能超过50个字节
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 增费：输入0.00-999.99（最多包含两位小数）<br/><font color=blue>增费可以为0</font><br/><font color=red>输入的格式分号个数和template_types数量一致，逗号个数必须与template_dests以分号隔开之后一一对应的数量一致</font>
        /// </summary>
        public string TemplateAddFees { get; set; }

        /// <summary>
        /// 增费标准：当valuation(记价方式)为0时输入1-9999范围内的整数<br><font color=blue>增费标准目前只能为1</font> <br><font color=red>输入的格式分号个数和template_types数量一致，逗号个数必须与template_dests以分号隔开之后一一对应的数量一致</font>
        /// </summary>
        public string TemplateAddStandards { get; set; }

        /// <summary>
        /// 邮费子项涉及的地区.结构: value1;value2;value3,value4 <br>如:1,110000;1,110000;1,310000;1,320000,330000。 aredId解释(1=全国,110000=北京,310000=上海,320000=江苏,330000=浙江) 如果template_types设置为post;ems;exmpress;cod则表示为平邮(post)指定默认地区(全国)和北京地区的运费;其他的类似以分号区分一一对应 <br/>可以用taobao.areas.get接口获取.或者参考：http://www.stats.gov.cn/tjbz/xzqhdm/t20080215_402462675.htm <br/><font color=red>每个运费方式设置的设涉及地区中必须包含全国地区（areaId=1）表示默认运费,可以只设置默认运费</font> <br><font color=blue>注意:为多个地区指定指定不同（首费标准、首费、增费标准、增费一项不一样就算不同）的运费以逗号","区分， template_start_standards(首费标准)、template_start_fees(首费)、 template_add_standards(增费标准)、 template_add_fees(增费)必须与template_types分号数量相同。如果为需要为多个地区指定相同运费则地区之间用“|”隔开即可。</font> <font color=red>如果卖家没有传入发货地址则默认地址库的发货地址</font>
        /// </summary>
        public string TemplateDests { get; set; }

        /// <summary>
        /// 首费：输入0.01-999.99（最多包含两位小数）  <br/><font color=blue> 首费不能为0</font><br><font color=red>输入的格式分号个数和template_types数量一致，逗号个数必须与template_dests以分号隔开之后一一对应的数量一致</font>
        /// </summary>
        public string TemplateStartFees { get; set; }

        /// <summary>
        /// 首费标准：当valuation(记价方式)为0时输入1-9999范围内的整数<br><font color=blue>首费标准目前只能为1</br> <br><font color=red>输入的格式分号个数和template_types数量一致，逗号个数必须与template_dests以分号隔开之后一一对应的数量一致</font>
        /// </summary>
        public string TemplateStartStandards { get; set; }

        /// <summary>
        /// 运费方式:平邮 (post),快递公司(express),EMS (ems),货到付款(cod)结构:value1;value2;value3;value4   如: post;express;ems;cod   <br/><font color=red>  注意:在添加多个运费方式时,字符串中使用 ";" 分号区分  。template_dests(指定地区)  template_start_standards(首费标准)、template_start_fees(首费)、template_add_standards(增费标准)、template_add_fees(增费)必须与template_types的分号数量相同. </font>  <br>  <font color=blue>普通用户：post,ems,express三种运费方式必须填写一个，不能填写cod。  货到付款用户：如果填写了cod运费方式，则post,ems,express三种运费方式也必须填写一个，如果没有填写cod则填写的运费方式中必须存在express</font>
        /// </summary>
        public string TemplateTypes { get; set; }

        /// <summary>
        /// 可选值：0<br>说明：<br>0:表示按宝贝件数计算运费
        /// </summary>
        public Nullable<long> Valuation { get; set; }

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.delivery.template.add";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("assumer", this.Assumer);
            parameters.Add("name", this.Name);
            parameters.Add("template_add_fees", this.TemplateAddFees);
            parameters.Add("template_add_standards", this.TemplateAddStandards);
            parameters.Add("template_dests", this.TemplateDests);
            parameters.Add("template_start_fees", this.TemplateStartFees);
            parameters.Add("template_start_standards", this.TemplateStartStandards);
            parameters.Add("template_types", this.TemplateTypes);
            parameters.Add("valuation", this.Valuation);
            return parameters;
        }

        public void Validate()
        {
            RequestValidator.ValidateRequired("assumer", this.Assumer);
            RequestValidator.ValidateRequired("name", this.Name);
            RequestValidator.ValidateMaxLength("name", this.Name, 50);
            RequestValidator.ValidateRequired("template_add_fees", this.TemplateAddFees);
            RequestValidator.ValidateRequired("template_add_standards", this.TemplateAddStandards);
            RequestValidator.ValidateRequired("template_dests", this.TemplateDests);
            RequestValidator.ValidateRequired("template_start_fees", this.TemplateStartFees);
            RequestValidator.ValidateRequired("template_start_standards", this.TemplateStartStandards);
            RequestValidator.ValidateRequired("template_types", this.TemplateTypes);
            RequestValidator.ValidateRequired("valuation", this.Valuation);
        }

        #endregion
    }
}
