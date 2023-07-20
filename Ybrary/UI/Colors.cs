using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Ybrary.UI
{
    public class Colors
    {
        /// <summary>
        /// RGB 값을 Color 객체로 변환
        /// </summary>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        /// <returns></returns>
        public Color ConvertRgbToColor(int red, int green, int blue)
        {
            return Color.FromArgb((byte)red, (byte)green, (byte)blue);
        }

        /// <summary>
        /// Color 객체에서 RGB 추출
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public (int red, int green, int blue) ConvertColorToRgb(Color color)
        {
            return (color.R, color.G, color.B);
        }

    }
}
