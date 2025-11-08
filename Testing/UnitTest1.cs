using SIGU.API.Controllers;

namespace Testing
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Class data = new Class();

            int resultado = data.sumar(2, 2, 1);
            Assert.Equal(4, resultado);
        } //Agregar los otros 3 


        [Fact]
        public void Test2()
        {
            Class data = new Class();

            int resultado = data.sumar(1, 2, 1);
            Assert.Equal(3, resultado);
        } //Agregar los otros 3 


        public void Test3()
        {

        }
    }
}

