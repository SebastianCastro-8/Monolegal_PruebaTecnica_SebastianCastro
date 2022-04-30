using GenFu;
using Monolegal_PruebaTecnica_SebastianCastro.Dominio.Dto;
using Monolegal_PruebaTecnica_SebastianCastro.Dominio.Models;
using Monolegal_PruebaTecnica_SebastianCastro.Utils;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monolegal_PruebaTecnica_SebastianCastro_Tests.Aplication
{
    public class EmailUtilTests
    {
        private Mock<IEmailUtil> _mailUtil;
        [SetUp]
        public void SetUp()
        {
            _mailUtil = new Mock<IEmailUtil>();
        }
        [Test]
        public async Task EmailTest()
        {
            var dto = A.New<FacturaDto>();
            var usuario = new Usuario("Npmbre1","Email1");
            var factura = new Factura(dto,usuario);
            await _mailUtil.Object.SendMail(factura,"facPrev");
        }
    }
}
