namespace ProyectoInnovaDESK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INICIAL : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accesos",
                c => new
                    {
                        pkAcceso = c.Int(nullable: false, identity: true),
                        dFecha = c.DateTime(nullable: false, precision: 0),
                        usuario_pkUsuario = c.Int(),
                    })
                .PrimaryKey(t => t.pkAcceso)
                .ForeignKey("dbo.Usuarios", t => t.usuario_pkUsuario)
                .Index(t => t.usuario_pkUsuario);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        pkUsuario = c.Int(nullable: false, identity: true),
                        sUsuario = c.String(unicode: false),
                        sPassword = c.String(unicode: false),
                        sNombre = c.String(unicode: false),
                        sAppellidos = c.String(unicode: false),
                        bStatus = c.Boolean(nullable: false),
                        rol_pkRol = c.Int(),
                    })
                .PrimaryKey(t => t.pkUsuario)
                .ForeignKey("dbo.Roles", t => t.rol_pkRol)
                .Index(t => t.rol_pkRol);
            
            CreateTable(
                "dbo.Candidatas",
                c => new
                    {
                        pkCandidata = c.Int(nullable: false, identity: true),
                        sNombre = c.String(nullable: false, unicode: false),
                        sApellido = c.String(nullable: false, unicode: false),
                        dfnac = c.DateTime(nullable: false, precision: 0),
                        sCorreo = c.String(nullable: false, unicode: false),
                        sCurp = c.String(nullable: false, unicode: false),
                        sNivelEstudios = c.String(nullable: false, unicode: false),
                        fotografia = c.String(nullable: false, unicode: false),
                        sAnioConvocatoria = c.String(nullable: false, unicode: false),
                        sDescripcion = c.String(unicode: false),
                        bStatus = c.Boolean(nullable: false),
                        municipio_pkMunicipio = c.Int(),
                        usuarios_pkUsuario = c.Int(),
                    })
                .PrimaryKey(t => t.pkCandidata)
                .ForeignKey("dbo.Municipios", t => t.municipio_pkMunicipio)
                .ForeignKey("dbo.Usuarios", t => t.usuarios_pkUsuario)
                .Index(t => t.municipio_pkMunicipio)
                .Index(t => t.usuarios_pkUsuario);
            
            CreateTable(
                "dbo.Municipios",
                c => new
                    {
                        pkMunicipio = c.Int(nullable: false, identity: true),
                        sNombre = c.String(nullable: false, unicode: false),
                        logotipo = c.String(nullable: false, unicode: false),
                        sDescripcion = c.String(unicode: false),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.pkMunicipio);
            
            CreateTable(
                "dbo.Ranking",
                c => new
                    {
                        pkRanking = c.Int(nullable: false, identity: true),
                        candidata_pkCandidata = c.Int(),
                    })
                .PrimaryKey(t => t.pkRanking)
                .ForeignKey("dbo.Candidatas", t => t.candidata_pkCandidata)
                .Index(t => t.candidata_pkCandidata);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        pkRol = c.Int(nullable: false, identity: true),
                        sNombre = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.pkRol);
            
            CreateTable(
                "dbo.PermisosNegados",
                c => new
                    {
                        pkPermisoNegado = c.Int(nullable: false, identity: true),
                        permiso_pkPermiso = c.Int(),
                        rol_pkRol = c.Int(),
                    })
                .PrimaryKey(t => t.pkPermisoNegado)
                .ForeignKey("dbo.Permisos", t => t.permiso_pkPermiso)
                .ForeignKey("dbo.Roles", t => t.rol_pkRol)
                .Index(t => t.permiso_pkPermiso)
                .Index(t => t.rol_pkRol);
            
            CreateTable(
                "dbo.Permisos",
                c => new
                    {
                        pkPermiso = c.Int(nullable: false, identity: true),
                        sNombre = c.String(unicode: false),
                        sDescripcion = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.pkPermiso);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "rol_pkRol", "dbo.Roles");
            DropForeignKey("dbo.PermisosNegados", "rol_pkRol", "dbo.Roles");
            DropForeignKey("dbo.PermisosNegados", "permiso_pkPermiso", "dbo.Permisos");
            DropForeignKey("dbo.Candidatas", "usuarios_pkUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.Ranking", "candidata_pkCandidata", "dbo.Candidatas");
            DropForeignKey("dbo.Candidatas", "municipio_pkMunicipio", "dbo.Municipios");
            DropForeignKey("dbo.Accesos", "usuario_pkUsuario", "dbo.Usuarios");
            DropIndex("dbo.PermisosNegados", new[] { "rol_pkRol" });
            DropIndex("dbo.PermisosNegados", new[] { "permiso_pkPermiso" });
            DropIndex("dbo.Ranking", new[] { "candidata_pkCandidata" });
            DropIndex("dbo.Candidatas", new[] { "usuarios_pkUsuario" });
            DropIndex("dbo.Candidatas", new[] { "municipio_pkMunicipio" });
            DropIndex("dbo.Usuarios", new[] { "rol_pkRol" });
            DropIndex("dbo.Accesos", new[] { "usuario_pkUsuario" });
            DropTable("dbo.Permisos");
            DropTable("dbo.PermisosNegados");
            DropTable("dbo.Roles");
            DropTable("dbo.Ranking");
            DropTable("dbo.Municipios");
            DropTable("dbo.Candidatas");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Accesos");
        }
    }
}
