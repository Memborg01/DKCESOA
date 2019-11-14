using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpers
{
    public class PriceHelper
    {
        // Parcels is divided into three different size
        // categories: A, B, C. A parcel is in category A if all
        // dimensions: height, depth, width are below 25 etc. 
        private float _sizeA = 25;
        private float _sizeB = 40;
        private float _sizeC = 200;

        // A Parcel is in weight category small, if it weighs less than 1.
        // It is in category medium if it weighs between 1 and 5.
        // It is in category large if it weighs more than 5.
        private float _weightA = 1;
        private float _weightB = 5;

        // These are the prices of parcels in the different categories.
        // priceMediumA is the price of sending a parcel between two consecutive nodes by air
        // which is of medium weight and size A.
        private float _priceLightA = 40;
        private float _priceMediumA = 60;
        private float _priceHeavyA = 80;
        private float _priceLightB = 48;
        private float _priceMediumB = 68;
        private float _priceHeavyB = 88;
        private float _priceLightC = 80;
        private float _priceMediumC = 100;
        private float _priceHeavyC = 120;

        //Return largest dimension of parcel for weight categorization.
        //Returns -1 if any dimension is sharply larger than 200 or less than or equal to 0.
        //The dimensions are in cm.
        public float GetLargestDimension(float height, float depth, float width)
        {
            float largestDimension = 0;

            if (height > 200 || depth > 200 || width > 200)
            {
                return -1;
            }
            if (height <= 0 || depth <= 0 || width <= 0)
            {
                return -1;
            }

            if (height > largestDimension)
            {
                largestDimension = height;
            }
            if (depth > largestDimension)
            {
                largestDimension = depth;
            }
            if (width > largestDimension)
            {
                largestDimension = width;
            }

            return largestDimension;
        }

        //Returns the weight category of a parcel. Either 1 for "light", 2 for "medium" or 3 for "heavy".
        //_weightA and _weightB defines what is light, medium and heavy.
        //If the parcel weighs more than 200, or has weight less than or equal to 0 return -1.
        //The weight is in kg.
        public int GetWeightCategory(float weight)
        {
            if (0 < weight && weight < _weightA)
            {
                return 1;
            }
            if (_weightA <= weight && weight <= _weightB)
            {
                return 2;
            }
            if (_weightB < weight && weight <= 20)
            {
                return 3;
            }

            //The parcel is too heavy.
            return -1;
        }

        // Returns the price of sending a parcel by air between two consecutive nodes.
        // Input is weight and dimensions such that the parcel may be categorized into
        // size and weight categories which define the price.
        // Dimensions are in cm and weight is in kg.
        // Returns -1 on error.
        public int CalculatePriceConsecutiveNodes(float weight, float height, float depth, float width)
        {
            float largestDimension = GetLargestDimension(height, depth, width);
            int weightCategory = GetWeightCategory(weight);
            float price = 0;

            //Error if weight is out of bounds of category definitions.
            if (weightCategory == -1)
            {
                return -1;
            }
            //Error if largest dimension is out of bounds.
            if ((int)largestDimension == -1)
            {
                return -1;
            }

            //Assign price in size category A.
            if (largestDimension < _sizeA)
            {
                if (weightCategory == 1)
                {
                    price = _priceLightA;
                }
                if (weightCategory == 2)
                {
                    price = _priceMediumA;
                }
                if (weightCategory == 3)
                {
                    price = _priceHeavyA;
                }
            }
            //Assign price in size category B.
            if (_sizeA <= largestDimension && largestDimension < _sizeB)
            {
                if (weightCategory == 1)
                {
                    price = _priceLightB;
                }
                if (weightCategory == 2)
                {
                    price = _priceMediumB;
                }
                if (weightCategory == 3)
                {
                    price = _priceHeavyB;
                }
            }
            // Assign price in size category C.
            if (_sizeB <= largestDimension && largestDimension <= _sizeC)
            {
                if (weightCategory == 1)
                {
                    price = _priceLightC;
                }
                if (weightCategory == 2)
                {
                    price = _priceMediumC;
                }
                if (weightCategory == 3)
                {
                    price = _priceHeavyC;
                }
            }
            return (int)price;
        }
    }
}