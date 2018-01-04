using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Food
{
    class FoodDictionary
    {
        Dictionary<string, string[]> foodDic; // 액셀에서 읽은 모든 데이터를 담는 컬렉션

        public FoodDictionary()
        {
            insert();
        }

        public void insert() // 액셀에서 읽은 데이터를 Dictionary 컬렉션에 삽입해주는 함수
        {
            ExcelIO excel = new ExcelIO();

            foodDic = excel.ReadExcel();
            
        }

        public List<string[]> search(string name, double weight) // 식재료 이름과 중량을 입력하고 검색해서 출력해주는 함수.
        {                                                       // 여러 식재료가 검색될수 있으므로 List로 담아줌
            List<string[]> searchResult = new List<string[]>();

            List<string> fkeys = new List<string>(foodDic.Keys);
            
            foreach(string element in fkeys)
            {
                if (element.Contains(name))
                {
                    string[] insertData = new string[foodDic[element].Length+2]; //한 줄(List 하나) 구성요소 - 
                                                                                // 이름[0], 중량[1], 각 성분들[2~]
                    insertData[0] = element;
                    insertData[1] = weight.ToString();

                    Array.Copy(weightConvert(foodDic[element],weight), 0, insertData, 2, foodDic[element].Length);

                    searchResult.Add(insertData);
                }
            }

            return searchResult;
        }
        

        private string[] weightConvert(string[] target, double weight) // 음식성분 데이터를 중량에 맞게 변환시켜주는 함수
        {
            string[] convertResult = new string[target.Length];

            for(int i=0; i<target.Length; i++)
            {
                double convertIndex = Convert.ToDouble(target[i]) * weight/100;
                convertResult[i] = convertIndex.ToString();
            }

            return convertResult;
        }
    }
}
