
public class Rootobject
{
    public Attributelevelmapstr attributeLevelMapStr { get; set; }
    public Attribute[] attributes { get; set; }
    public Levelattrrellist[] levelAttrRelList { get; set; }
}

public class Attributelevelmapstr
{
    public string _18113289490 { get; set; }
    public string _248963870466243 { get; set; }
    public string _1000006913261229 { get; set; }
    public string _18228222321958 { get; set; }
    public string _10000069146874710821958 { get; set; }
    public string _24896381084918217 { get; set; }
    public string _24896389955810 { get; set; }
    public string _248963891043051 { get; set; }
    public string _10000069146874 { get; set; }
    public string _248963829339041 { get; set; }
    public string _10000069112767422 { get; set; }
    public string _15448652521958 { get; set; }
}

public class Attribute
{
    public int attrID { get; set; }
    public string name { get; set; }
    public bool required { get; set; }
    public string fieldType { get; set; }
    public bool isSKUAttribute { get; set; }
    public Attrvalue[] attrValues { get; set; }
    public string inputType { get; set; }
    public string aspect { get; set; }
    public bool isSpecPicAttr { get; set; }
    public string[] units { get; set; }
}

public class Attrvalue
{
    public long attrValueID { get; set; }
    public string name { get; set; }
}

public class Levelattrrellist
{
    public int fid { get; set; }
    public int[] subFids { get; set; }
    public Sub[] subs { get; set; }
}

public class Sub
{
    public int fid { get; set; }
    public int[] subFids { get; set; }
}
