using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Models
{
    public class SiteProvider
    {
        CSContext context;
        public SiteProvider(CSContext context)
        {
            //Khuyết điểm
            //Tự động khởi tạo
            this.context = context;
        }
        //Fileds
        public RoleRepository role;
        public AccessRepository access;
        public MemberRepository member;
        public ProvinceRepository province;
        public DistrictRepository district;
        public WardRepository ward;
        public SuperstoreRepository superstore;
        public ImageRepository image;
        public CategoryRepository category;
        public PdfRepository pdf;

        public PdfRepository Pdf 
        {
            get
            {
                if (pdf is null)
                {
                    pdf = new PdfRepository(context);
                }
                return pdf;
            }
        }
        public CategoryRepository Category
        {
            get
            {
                if (category == null)
                {
                    category = new CategoryRepository(context);
                }
                return category;
            }
        }
        public ImageRepository Image
        {
            get
            {
                if (image==null)
                {
                    image = new ImageRepository(context);
                }
                return image;
                
            }
        }

        public SuperstoreRepository Superstore
        {
            get
            {
                if (superstore == null)
                {
                    superstore = new SuperstoreRepository(context);
                }
                return superstore;
            }
        }
        public WardRepository Ward
        {
            get
            {
                if (ward is null)
                {
                    ward = new WardRepository(context);
                }
                return ward;
            }
        }
        public DistrictRepository District
        {
            get
            {
                if (district is null)
                {
                    district = new DistrictRepository(context);
                }
                return district;
            }
        }
        public ProvinceRepository Province 
        { 
            get
            {
                if (province is null)
                {
                    province = new ProvinceRepository(context);
                }
                return province;
            }
            
        }
        //properties
        public AccessRepository Access 
        { 
             get
            {
                if (access is null)
                {
                    access = new AccessRepository(context);
                }
                return access;
            }
            
        }
        public RoleRepository Role
        {
            get
            {
                if (role is null)
                {
                    role = new RoleRepository(context);
                }
                return role;
                //return role ?? new RoleRepository(context);
            }
        }
    }
}
