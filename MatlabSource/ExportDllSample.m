function [xArrayOut,yArrayOut] = ShowPlot(xArrayIn,yArrayIn)
    %显示图表
    plot(xArrayIn,yArrayIn);
    xArrayOut = xArrayIn;
    yArrayOut = yArrayIn;
end