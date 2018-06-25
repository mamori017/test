import unittest
from hello import hello

class testHello(unittest.TestCase):

    def test_hello(self):
        str = "hello" 
        ret = hello()
        self.assertEqual(str,ret)

if __name__ == "__main__":
    unittest.main()