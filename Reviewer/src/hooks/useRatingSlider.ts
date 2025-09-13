import { useState, useEffect } from "react";

export const useRatingSlider = (initialValue: number = 0) => {
    const [ratingValue, setRatingValue] = useState(initialValue);
    const [isInteracting, setIsInteracting] = useState(false);

    useEffect(() => {
        setRatingValue(initialValue);
    }, [initialValue]);

    const handleChange = (newValue: number) => {
        setRatingValue(newValue);
        if (!isInteracting) setIsInteracting(true);
    };

    const getSectionColor = (point: number) => {
        switch (point) {
            case 1: return "#ff4444";
            case 2:
            case 3: return "#ff8c00";
            case 4:
            case 5: return "#ffcc00";
            default: return "#DCDCDC";
        }
    };

    const getDotColor = (point: number) => {
        if (!isInteracting && initialValue === 0) return getSectionColor(point);
        if (ratingValue > 0) return point <= ratingValue ? getSectionColor(ratingValue) : "#FFFFFF";
        return "#FFFFFF";
    };

    return {
        ratingValue,
        isInteracting,
        handleChange,
        getSectionColor,
        getDotColor,
    };
};
